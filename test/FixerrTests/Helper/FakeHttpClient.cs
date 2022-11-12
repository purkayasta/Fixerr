using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FixerrTests.Helper;

internal class FakeHttpClient
{
    internal static HttpClient Create(string jsonData)
    {
        return new HttpClient(new FakeHttpMessageHandler(async (request, cancellationToken) =>
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonData ?? null, Encoding.UTF8, "application/json")
            };

            return await Task.FromResult(responseMessage);
        }));
    }
}
