using System.Text;
using System.Text.Json;
using FixSharp.Models;

namespace FixSharp
{
    public class FixSharper
    {
        private readonly HttpClient _httpClient;

        public FixSharper(HttpClient httpClient)
        {
            httpClient = httpClient ?? throw new ArgumentNullException("HTTP Client instance is null, please make sure you have passed the proper and good HTTP client");
            httpClient.BaseAddress = FixerConstants.BaseUrl;
            _httpClient = httpClient;
        }

        public async ValueTask<LatestRates> GetLatest(string baseCurrency = null, string symbols = null)
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append("latest");
            urlBuilder.Append($"?access_key={FixerConstants.ApiKey}");
            if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
            if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"symbols={symbols}");

            var stream = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            return await JsonSerializer.DeserializeAsync<LatestRates>(stream);
        }
    }
}
