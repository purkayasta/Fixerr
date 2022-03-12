using System.Text;
using System.Text.Json;
using Fixerr.Models;

namespace Fixerr
{
    public sealed class FixerClient : IFixerClient
    {
        private readonly HttpClient _httpClient;
        public FixerClient(HttpClient httpClient)
        {
            httpClient = httpClient ?? throw new ArgumentNullException("HTTP Client instance is null, please make sure you have passed the proper and good HTTP client");
            httpClient.BaseAddress = FixerEnvironment.BaseUrl;
            _httpClient = httpClient;
        }

        public async ValueTask<LatestRateResponse> GetLatestAsync(string baseCurrency = null, string symbols = null)
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append("latest");
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");
            if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
            if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var latestResponse = await JsonSerializer.DeserializeAsync<LatestRateResponse>(streamResponse)
                                                     .ConfigureAwait(false);
            return latestResponse;
        }
        public async ValueTask<SymbolResponse> GetSymbolAsync()
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append("latest");
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var symbolResponse = await JsonSerializer.DeserializeAsync<SymbolResponse>(streamResponse)
                                                     .ConfigureAwait(false);
            return symbolResponse;
        }
        public async ValueTask<HistoricRateResponse> GetHistoricRateAsync(DateOnly sourceDate, string baseCurrency = null, string symbols = null)
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append(sourceDate.ToString("YYYY-MM-DD"));
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");

            if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
            if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var historicResponse = await JsonSerializer.DeserializeAsync<HistoricRateResponse>(streamResponse)
                                                       .ConfigureAwait(false);
            return historicResponse;
        }
        public async ValueTask<CurrencyConvertResponse> GetConvertionAsync(string from, string to, int amount, string historialDate = null)
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append("convert");
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");
            if (string.IsNullOrEmpty(from)) throw new ArgumentException("From parameter is required");
            if (string.IsNullOrEmpty(to)) throw new ArgumentException("To parameter is required");
            if (amount < 0) throw new ArgumentException("Amount is required");

            urlBuilder.Append("&from={from}");
            urlBuilder.Append("&to={to}");
            urlBuilder.Append("&amount={amount}");

            if (!string.IsNullOrEmpty(historialDate))
                if (DateOnly.TryParse(historialDate, out var date))
                    urlBuilder.Append($"&date={date.ToString("YYYY-MM-DD")}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var currencyConvertionResponse = await JsonSerializer.DeserializeAsync<CurrencyConvertResponse>(streamResponse)
                                                                 .ConfigureAwait(false);
            return currencyConvertionResponse;
        }
    }
}
