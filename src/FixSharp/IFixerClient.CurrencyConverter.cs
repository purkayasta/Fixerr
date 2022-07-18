// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    Task<CurrencyConverter> GetConvertionAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);
    Task<HttpResponseMessage> GetCurrencyConverterRawAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);
    Task<string> GetCurrencyConvertedStringAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);
}