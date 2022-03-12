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
        public async ValueTask<HistoricRateResponse> GetHistoricRateAsync(string sourceDate, string baseCurrency = null, string symbols = null)
        {
            if (string.IsNullOrEmpty(sourceDate)) throw new ArgumentNullException($"{nameof(sourceDate)} is required");

            if (!DateOnly.TryParseExact(sourceDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception($"{sourceDate} is not in the valid date format");

            StringBuilder urlBuilder = new();
            urlBuilder.Append(sourceDate);
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
            if (string.IsNullOrEmpty(from)) throw new ArgumentException("From parameter is required");
            if (string.IsNullOrEmpty(to)) throw new ArgumentException("To parameter is required");
            if (amount < 0) throw new ArgumentException("Amount is required");

            StringBuilder urlBuilder = new();
            urlBuilder.Append("convert");
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");

            urlBuilder.Append("&from={from}");
            urlBuilder.Append("&to={to}");
            urlBuilder.Append("&amount={amount}");

            if (!string.IsNullOrEmpty(historialDate))
                if (DateOnly.TryParseExact(historialDate, FixerEnvironment.FixerDateFormat, out DateOnly _))
                    urlBuilder.Append($"&date={historialDate}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var convertResponse = await JsonSerializer.DeserializeAsync<CurrencyConvertResponse>(streamResponse)
                                                                 .ConfigureAwait(false);
            return convertResponse;
        }
        public async ValueTask<TimeSeriesResponse> GetTimeSeriesAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null)
        {
            if (string.IsNullOrEmpty(startDate)) throw new NullReferenceException("Start Date is Required");
            if (string.IsNullOrEmpty(endDate)) throw new NullReferenceException("End Date is Required");

            if (!DateOnly.TryParseExact(startDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception("Start date is not in the valid date format");
            if (!DateOnly.TryParseExact(endDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception("End date is not in the valid date format");

            StringBuilder urlBuilder = new();
            urlBuilder.Append("timeseries");
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");
            urlBuilder.Append($"&start_date={startDate}");
            urlBuilder.Append($"&end_date={endDate}");

            if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
            if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var timeSeriesResponse = await JsonSerializer.DeserializeAsync<TimeSeriesResponse>(streamResponse)
                                                                 .ConfigureAwait(false);
            return timeSeriesResponse;
        }
        public async ValueTask<FluctuationResponse> GetFluctuationAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null)
        {
            if (string.IsNullOrEmpty(startDate)) throw new NullReferenceException("Start Date is Required");
            if (string.IsNullOrEmpty(endDate)) throw new NullReferenceException("End Date is Required");

            if (!DateOnly.TryParseExact(startDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception("Start date is not in the valid date format");
            if (!DateOnly.TryParseExact(endDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception("End date is not in the valid date format");

            StringBuilder urlBuilder = new();
            urlBuilder.Append("fluctuation");
            urlBuilder.Append($"?access_key={FixerEnvironment.ApiKey}");
            urlBuilder.Append($"&start_date={startDate}");
            urlBuilder.Append($"&end_date={endDate}");

            if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
            if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");

            var streamResponse = await _httpClient.GetStreamAsync(urlBuilder.ToString());
            var fluctuationResponse = await JsonSerializer.DeserializeAsync<FluctuationResponse>(streamResponse)
                                                                 .ConfigureAwait(false);
            return fluctuationResponse;
        }
    }
}
