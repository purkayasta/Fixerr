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
    public async Task<HistoricRate> GetHistoricRateAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        string url = BuildHistoricRateUrl(sourceDate, baseCurrency, symbols, apiKey);

        var streamResponse = await _httpClient.GetStreamAsync(url);
        var historicResponse = await JsonSerializer.DeserializeAsync<HistoricRate>(streamResponse).ConfigureAwait(false);
        return historicResponse;
    }

    public Task<HttpResponseMessage> GetHistoricRateRawAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        string url = BuildHistoricRateUrl(sourceDate, baseCurrency, symbols, apiKey);
        return _httpClient.GetAsync(url);
    }

    public Task<string> GetHistoricRateStringAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        string url = BuildHistoricRateUrl(sourceDate, baseCurrency, symbols, apiKey);
        return _httpClient.GetStringAsync(url);
    }

    private static string BuildHistoricRateUrl(string sourceDate, string baseCurrency, string symbols, string apiKey)
    {
        if (string.IsNullOrEmpty(sourceDate)) throw new InvalidDataException($"{nameof(sourceDate)} is required");

        if (!DateOnly.TryParseExact(sourceDate, FixerEnvironment.FixerDateFormat, out DateOnly _)) throw new Exception($"{sourceDate} is not in the valid date format");

        StringBuilder urlBuilder = new();
        urlBuilder.Append(sourceDate);
        urlBuilder.Append($"?access_key={apiKey ?? FixerEnvironment.ApiKey}");

        if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
        if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");

        return urlBuilder.ToString();
    }
}