using Fixerr.Models;

namespace Fixerr;

public partial interface IFixerClient
{
    Task<LatestRate> GetLatestRateAsync(string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<HttpResponseMessage> GetLatestRateRawAsync(string baseCurrency = null, string symbols = null, string apiKey = null);
    Task<string> GetLatestRateStringAsync(string baseCurrency = null, string symbols = null, string apiKey = null);
}

