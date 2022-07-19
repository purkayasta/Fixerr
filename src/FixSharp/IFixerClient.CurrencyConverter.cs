// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    /// <summary>returns the converted currency from one to another</summary>
    /// <returns>CurrencyConverter</returns>
    Task<CurrencyConverter> GetConvertionAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);

    /// <summary>returns the converted currency from one to another</summary>
    /// <returns>HttpResponseMessage</returns>
    Task<HttpResponseMessage> GetCurrencyConverterRawAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);

    /// <summary>returns the converted currency from one to another</summary>
    /// <returns>string</returns>
    Task<string> GetCurrencyConvertedStringAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);
}