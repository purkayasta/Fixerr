// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    /// <summary>returns historic rates data all the way back to 1999</summary>
    /// <returns>HistoricRate</returns>
    Task<HistoricRate?> GetHistoricRateAsync(string sourceDate, string? baseCurrency = null, string? symbols = null, string? apiKey = null);

    /// <summary>returns historic rates data all the way back to 1999</summary>
    /// <returns>HttpResponseMessage</returns>
    Task<HttpResponseMessage> GetHistoricRateRawAsync(string sourceDate, string? baseCurrency = null, string? symbols = null, string? apiKey = null);

    /// <summary>returns historic rates data all the way back to 1999</summary>
    /// <returns>string</returns>
    Task<string> GetHistoricRateStringAsync(string sourceDate, string? baseCurrency = null, string? symbols = null, string? apiKey = null);
}