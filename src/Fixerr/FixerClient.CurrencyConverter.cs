// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------


using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fixerr.Configurations;
using Fixerr.Models;

namespace Fixerr;

internal sealed partial class FixerClient : IFixerClient
{
    public async Task<CurrencyConverter> GetCurrencyConverterAsync(
        string from,
        string to,
        int amount,
        string historicalDate = null,
        string apiKey = null)
    {
        using System.IO.Stream streamResponse = await HttpClient!.GetStreamAsync(BuildCurrencyUrl(from, to, amount, historicalDate, apiKey));
        return await JsonSerializer.DeserializeAsync<CurrencyConverter>(streamResponse).ConfigureAwait(false);
    }

    public Task<HttpResponseMessage> GetCurrencyConverterRawAsync(string from, string to, int amount, string historicalDate = null, string apiKey = null)
        => HttpClient!.GetAsync(BuildCurrencyUrl(from, to, amount, historicalDate, apiKey));

    public Task<string> GetCurrencyConverterStringAsync(
        string from,
        string to,
        int amount,
        string historicalDate = null,
        string apiKey = null)
    {
        return HttpClient!.GetStringAsync(BuildCurrencyUrl(from, to, amount, historicalDate, apiKey));
    }

    private static string BuildCurrencyUrl(
        string from,
        string to,
        int amount,
        string historicalDate,
        string apiKey)
    {
        if (string.IsNullOrEmpty(from) || string.IsNullOrWhiteSpace(from))
            throw new ArgumentException(nameof(from) + " is required");
        if (string.IsNullOrEmpty(to) || string.IsNullOrWhiteSpace(to))
            throw new ArgumentException(nameof(to) + " is required");
        if (amount < 0) throw new InvalidDataException("Amount is required");

        StringBuilder urlBuilder = new();
        urlBuilder.Append("convert");
        urlBuilder.Append($"?access_key={apiKey ?? FixerEnvironment.ApiKey}");

        urlBuilder.Append("&from={from}");
        urlBuilder.Append("&to={to}");
        urlBuilder.Append("&amount={amount}");

        if (string.IsNullOrEmpty(historicalDate)) return urlBuilder.ToString();

        if (DateOnly.TryParseExact(historicalDate, FixerEnvironment.FixerDateFormat, out DateOnly _))
            urlBuilder.Append($"&date={historicalDate}");
        else
            throw new InvalidDataException($" {historicalDate} => is not valid, please fix it {nameof(historicalDate)}");

        return urlBuilder.ToString();
    }
}