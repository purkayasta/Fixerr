// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Fixerr.Configurations;
using Microsoft.Extensions.Options;

[assembly: InternalsVisibleTo("FixerrTests")]

namespace Fixerr;

internal partial class FixerClient : IFixerClient
{
    private HttpClient HttpClient { get; }

    public FixerClient(HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        httpClient.BaseAddress = FixerEnvironment.BaseUri;
        this.HttpClient = httpClient;
    }

    public FixerClient(HttpClient httpClient, IOptions<FixerOptions> options)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(options);

        FixerEnvironment.ApiKey = options.Value.ApiKey!;
        FixerEnvironment.IsPaidSubscription = options.Value.IsPaidSubscription;
    }
}