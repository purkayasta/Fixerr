// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    Task<HistoricRate> GetHistoricRateAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<HttpResponseMessage> GetHistoricRateRawAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<string> GetHistoricRateStringAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null);
}