// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Microsoft.Extensions.Options;

namespace Fixerr.Configurations;

public static class FixerFactory
{
    public static IFixerClient CreateFixerClient(HttpClient httpClient, string apiKey, bool isPaidSubscription = false)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(apiKey);

        FixerOptions fixerOptions = new FixerOptions
        {
            ApiKey = apiKey,
            IsPaidSubscription = isPaidSubscription
        };

        IFixerClient instance = new FixerClient(httpClient, Options.Create(fixerOptions));
        return instance;
    }
}