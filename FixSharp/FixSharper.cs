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
        /// Depending on your subscription plan, the API's latest endpoint will return real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.
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

        /// <summary>
        /// The Fixer API comes with a constantly updated endpoint returning all available currencies. To access this list, make a request to the API's symbols endpoint.
        /// </summary>
        /// <returns></returns>
        public async ValueTask<SymbolResponse> GetSymbolAsync()
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append("latest");
            urlBuilder.Append($"?access_key={FixerConstants.ApiKey}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var symbolResponse = await JsonSerializer.DeserializeAsync<SymbolResponse>(streamResponse);
            return symbolResponse;
        }
    }
}
