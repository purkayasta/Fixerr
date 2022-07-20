// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

namespace Fixerr.Configurations;

public static class FixerFactory
{
    public static IFixerClient GetFixerClient(HttpClient httpClient, string apiKey)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(apiKey);

        IFixerClient instance = new FixerClient(httpClient, apiKey);
        return instance;
    }

    public static IFixerClient GetFixerClient(HttpClient httpClient, string apiKey, bool isPaidSubscription)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(apiKey);

        IFixerClient instance = new FixerClient(httpClient, apiKey, isPaidSubscription);
        return instance;
    }
}