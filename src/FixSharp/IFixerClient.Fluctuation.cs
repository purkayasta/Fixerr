// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    /// <summary>returns how currencies fluctuate on a day to day basis</summary>
    /// <returns>Fluctuation</returns>
    Task<Fluctuation> GetFluctuationAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);

    /// <summary>returns how currencies fluctuate on a day to day basis</summary>
    /// <returns>HttpResponseMessage</returns>
    Task<HttpResponseMessage> GetFluctuationRawAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);

    /// <summary>returns how currencies fluctuate on a day to day basis</summary>
    /// <returns>string</returns>
    Task<string> GetFluctuationStringAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
}