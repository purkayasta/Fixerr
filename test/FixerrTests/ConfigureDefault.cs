using System.Net.Http;
using System.Text.Json;
using Fixerr.Configurations;
using FixerrTests.Helper;
using Microsoft.Extensions.Options;

namespace FixerrTests;

internal class ConfigureDefault
{
    internal static HttpClient Get(object data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        var httpClient = FakeHttpClient.Create(jsonData);
        return httpClient;
    }

    internal static FixerOptions GetFixerOptions()
    {
        return new FixerOptions
        {
            ApiKey = "HelloWorld",
            IsPaidSubscription = true
        };
    }

    internal static IOptions<FixerOptions> GetFixerIOptions() => Options.Create(GetFixerOptions());
}
