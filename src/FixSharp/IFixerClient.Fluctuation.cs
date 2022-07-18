// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    Task<Fluctuation> GetFluctuationAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<HttpResponseMessage> GetFluctuationRawAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<string> GetFluctuationStringAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
}