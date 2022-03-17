using System.Net.Http;
using System.Text.Json;
using FixerrTests.Helper;

namespace FixerrTests
{
    internal class ConfigureDefault
    {
        internal static HttpClient Get(object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var httpClient = FakeHttpClient.Create(jsonData);
            return httpClient;
        }
    }
}
