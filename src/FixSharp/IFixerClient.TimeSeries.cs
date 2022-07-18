// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    Task<TimeSeries> GetTimeSeriesAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<HttpResponseMessage> GetTimeSeriesRawAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<string> GetTimeSeriesStringAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
}