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
    public async Task<CurrencyConverter> GetCurrencyConverterAsync(string from, string to, int amount, string historialDate = null, string apiKey = null)
    {
        string url = BuildCurrencyUrl(from, to, amount, historialDate, apiKey);

        var streamResponse = await _httpClient.GetStreamAsync(url);
        var convertResponse = await JsonSerializer.DeserializeAsync<CurrencyConverter>(streamResponse).ConfigureAwait(false);
        return convertResponse;
    }

    public Task<HttpResponseMessage> GetCurrencyConverterRawAsync(string from, string to, int amount, string historialDate = null, string apiKey = null)
    {
        string url = BuildCurrencyUrl(from, to, amount, historialDate, apiKey);
        return _httpClient.GetAsync(url);
    }

    public Task<string> GetCurrencyConverterStringAsync(string from, string to, int amount, string historialDate = null, string apiKey = null)
    {
        string url = BuildCurrencyUrl(from, to, amount, historialDate, apiKey);
        return _httpClient.GetStringAsync(url);
    }

    private static string BuildCurrencyUrl(string from, string to, int amount, string historialDate, string apiKey)
    {
        if (string.IsNullOrEmpty(from)) throw new ArgumentException("From parameter is required");
        if (string.IsNullOrEmpty(to)) throw new ArgumentException("To parameter is required");
        if (amount < 0) throw new ArgumentException("Amount is required");

        StringBuilder urlBuilder = new();
        urlBuilder.Append("convert");
        urlBuilder.Append($"?access_key={apiKey ?? FixerEnvironment.ApiKey}");

        urlBuilder.Append("&from={from}");
        urlBuilder.Append("&to={to}");
        urlBuilder.Append("&amount={amount}");

        if (!string.IsNullOrEmpty(historialDate))
        {
            if (DateOnly.TryParseExact(historialDate, FixerEnvironment.FixerDateFormat, out DateOnly _))
                urlBuilder.Append($"&date={historialDate}");
            else
                throw new Exception($" {historialDate} => is not valid, please fix it {nameof(historialDate)}");
        }

        return urlBuilder.ToString();
    }
}