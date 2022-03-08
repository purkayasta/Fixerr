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

        /// <summary>
        /// Get Latest Rates
        /// </summary>
        /// <param name="baseCurrency">Give the base currency, By Default base currency will be set to EUR by the API</param>
        /// <param name="symbols">Comma separated country's name</param>
        /// <returns></returns>
        public async ValueTask<LatestRateResponse> GetLatestAsync(string baseCurrency = null, string symbols = null)
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append("latest");
            urlBuilder.Append($"?access_key={FixerConstants.ApiKey}");
            if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
            if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"symbols={symbols}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var latestResponse = await JsonSerializer.DeserializeAsync<LatestRateResponse>(streamResponse);
            return latestResponse;
        }
    }
}
