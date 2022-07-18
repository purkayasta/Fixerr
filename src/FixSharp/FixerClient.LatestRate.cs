using System.Text;
using System.Text.Json;
using Fixerr.Models;

namespace Fixerr;

public partial class FixerClient : IFixerClient
{
    public async Task<LatestRate> GetLatestRateAsync(string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        var url = BuildLatestRateUrl(baseCurrency, symbols, apiKey);
        var streamResponse = await _httpClient.GetStreamAsync(url);
        return await JsonSerializer.DeserializeAsync<LatestRate>(streamResponse).ConfigureAwait(false);
    }

    public Task<HttpResponseMessage> GetLatestRateRawAsync(string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        var url = BuildLatestRateUrl(baseCurrency, symbols, apiKey);
        return _httpClient.GetAsync(url);
    }

    public Task<string> GetLatestRateStringAsync(string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        var url = BuildLatestRateUrl(baseCurrency, symbols, apiKey);
        return _httpClient.GetStringAsync(url);
    }

    private string BuildLatestRateUrl(string baseCurrency = null, string symbols = null, string apiKey = null)
    {
        StringBuilder urlBuilder = new();
        urlBuilder.Append("latest");
        urlBuilder.Append($"?access_key={apiKey ?? FixerEnvironment.ApiKey}");
        if (!string.IsNullOrEmpty(baseCurrency)) urlBuilder.Append($"&base={baseCurrency}");
        if (!string.IsNullOrEmpty(symbols)) urlBuilder.Append($"&symbols={symbols}");

        return urlBuilder.ToString();
    }
}
