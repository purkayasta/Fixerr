// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------


using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    /// <summary>returns real time exchange data</summary>
    /// <returns>LatestRate</returns>
    Task<LatestRate> GetLatestRateAsync(string baseCurrency = null, string symbols = null, string apiKey = null);

    /// <summary>returns real time exchange data</summary>
    /// <returns>HttpResponseMessage</returns>
    Task<HttpResponseMessage> GetLatestRateRawAsync(string baseCurrency = null, string symbols = null, string apiKey = null);

    /// <summary>returns real time exchange data</summary>
    /// <returns>string</returns>
    Task<string> GetLatestRateStringAsync(string baseCurrency = null, string symbols = null, string apiKey = null);
}

