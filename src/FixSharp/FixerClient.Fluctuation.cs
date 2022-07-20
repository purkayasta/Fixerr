// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System.Text;
using System.Text.Json;
using Fixerr.Models;

namespace Fixerr;

internal sealed partial class FixerClient : IFixerClient
{
    public async Task<Fluctuation> GetFluctuationAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        string url = BuildFluctuationUrl(startDate, endDate, baseCurrency, symbols, apiKey);

        var streamResponse = await _httpClient.GetStreamAsync(url);
        var fluctuationResponse = await JsonSerializer.DeserializeAsync<Fluctuation>(streamResponse).ConfigureAwait(false);
        return fluctuationResponse;
    }

    public Task<HttpResponseMessage> GetFluctuationRawAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        string url = BuildFluctuationUrl(startDate, endDate, baseCurrency, symbols, apiKey);
        return _httpClient.GetAsync(url);
    }

    public Task<string> GetFluctuationStringAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        string url = BuildTimeSeriesUrl(startDate, endDate, baseCurrency, symbols, apiKey);
        return _httpClient.GetStringAsync(url);
    }

    private static string BuildFluctuationUrl(string startDate, string endDate, string baseCurrency, string symbols, string apiKey)
    {
        if (string.IsNullOrEmpty(startDate)) throw new InvalidDataException("Start Date is Required");
        if (string.IsNullOrEmpty(endDate)) throw new InvalidDataException("End Date is Required");

        if (!DateOnly.TryParseExact(startDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception("Start date is not in the valid date format");
        if (!DateOnly.TryParseExact(endDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception("End date is not in the valid date format");

        StringBuilder urlBuilder = new();
        urlBuilder.Append("fluctuation");
        urlBuilder.Append($"?access_key={apiKey ?? FixerEnvironment.ApiKey}");
        urlBuilder.Append($"&start_date={startDate}");
        urlBuilder.Append($"&end_date={endDate}");

        if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
        if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");
        return urlBuilder.ToString();
    }
}