// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Configurations;

namespace Fixerr.Installer;

public static class FixerFactory
{
    /// <summary>
    /// Create fixer client for api access.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="apiKey">mandatory**</param>
    /// <param name="isPaidSubscription"></param>
    /// <returns></returns>
    public static IFixerClient CreateFixerClient(
        HttpClient? httpClient,
        string? apiKey,
        bool isPaidSubscription = false)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentException.ThrowIfNullOrEmpty(apiKey);

        FixerEnvironment.IsPaidSubscription = isPaidSubscription;
        FixerEnvironment.ApiKey = apiKey;

        return new FixerClient(httpClient);
    }
}