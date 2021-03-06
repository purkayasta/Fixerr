// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

namespace Fixerr;

internal sealed partial class FixerClient : IFixerClient
{
    private readonly HttpClient _httpClient;
    public FixerClient(HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        httpClient.BaseAddress = FixerEnvironment.BaseUrl;
        _httpClient = httpClient;
    }

    public FixerClient(HttpClient httpClient, string apiKey)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(apiKey);

        httpClient.BaseAddress = FixerEnvironment.BaseUrl;
        FixerEnvironment.ApiKey = apiKey;
        _httpClient = httpClient;
    }

    public FixerClient(HttpClient httpClient, string apiKey, bool isPaidSubscription)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(apiKey);

        httpClient.BaseAddress = FixerEnvironment.BaseUrl;
        _httpClient = httpClient;

        FixerEnvironment.ApiKey = apiKey;
        FixerEnvironment.IsPaidSubscription = isPaidSubscription;
    }
}
