// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Configurations;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FixerrTests")]

namespace Fixerr;

internal partial class FixerClient : IFixerClient
{
    private HttpClient? HttpClient { get; init; }

    public FixerClient(IHttpClientFactory httpClientFactory, IOptions<FixerOptions> options)
        : this(httpClientFactory.CreateClient(FixerEnvironment.HttpClientName), options)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
    }

    public FixerClient(HttpClient httpClient, IOptions<FixerOptions> options)
        : this(options)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        httpClient.BaseAddress = FixerEnvironment.BaseUri;

        this.HttpClient = httpClient;
    }

    private FixerClient(IOptions<FixerOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(options.Value);

        FixerEnvironment.ApiKey = options.Value.ApiKey;
        FixerEnvironment.IsPaidSubscription = options.Value.IsPaidSubscription;
    }
}