using System.Text;
using System.Text.Json;
using Fixerr.Models;

namespace Fixerr;

public partial class FixerClient : IFixerClient
{
    public async Task<Symbol> GetSymbolAsync(string apiKey = null)
    {
        string url = BuildSymbolUrl(apiKey);

        var streamResponse = await _httpClient.GetStreamAsync(url);
        var symbolResponse = await JsonSerializer.DeserializeAsync<Symbol>(streamResponse).ConfigureAwait(false);
        return symbolResponse;
    }

    public Task<HttpResponseMessage> GetSymbolRawAsync(string apiKey = null)
    {
        string url = BuildSymbolUrl(apiKey);
        return _httpClient.GetAsync(url);
    }

    public Task<string> GetSymbolStringAsync(string apiKey = null)
    {
        string url = BuildSymbolUrl(apiKey);
        return _httpClient.GetStringAsync(url);
    }

    private static string BuildSymbolUrl(string apiKey)
    {
        StringBuilder urlBuilder = new();
        urlBuilder.Append("latest");
        urlBuilder.Append($"?access_key={apiKey ?? FixerEnvironment.ApiKey}");
        return urlBuilder.ToString();
    }
}