// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Microsoft.Extensions.Options;

namespace Fixerr.Configurations;

public static class FixerFactory
{
    /// <summary>
    /// Create fixer client for api access.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="apiKey">mandatory**</param>
    /// <param name="isPaidSubscription"></param>
    /// <returns></returns>
    public static IFixerClient CreateFixerClient(HttpClient httpClient, string apiKey, bool isPaidSubscription = false)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentNullException(nameof(apiKey) + " is null or empty. Please provide a valid value");

        var fixerOptions = new FixerOptions
        {
            ApiKey = apiKey,
            IsPaidSubscription = isPaidSubscription
        };

        IFixerClient instance = new FixerClient(httpClient, Options.Create(fixerOptions));
        return instance;
    }
}