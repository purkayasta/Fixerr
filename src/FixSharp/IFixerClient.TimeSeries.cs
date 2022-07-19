// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    /// <summary>returns daily historic rates between two dates</summary>
    /// <returns>TimeSeries</returns>
    Task<TimeSeries> GetTimeSeriesAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);

    /// <summary>returns daily historic rates between two dates</summary>
    /// <returns>HttpResponseMessage</returns>
    Task<HttpResponseMessage> GetTimeSeriesRawAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);

    /// <summary>returns daily historic rates between two dates</summary>
    /// <returns>string</returns>
    Task<string> GetTimeSeriesStringAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
}