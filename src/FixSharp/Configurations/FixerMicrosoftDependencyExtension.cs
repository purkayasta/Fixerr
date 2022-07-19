// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace Fixerr.Configurations;

public static class FixerMicrosoftDependencyExtension
{
    /// <summary>Easy way to add all the dependency for this library to work</summary>
    /// <param name="apiKey">API KEY FOR FIXER TO WORK</param>
    public static void AddFixer(this IServiceCollection serviceCollection, string apiKey)
    {
        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey)) throw new NullReferenceException("Please provider proper api key for FIXER!!");

        serviceCollection.AddHttpClient();

        serviceCollection.AddScoped<IFixerClient>(x =>
        {
            return new FixerClient(x.GetRequiredService<HttpClient>(), apiKey);
        });
    }


    /// <summary>Easy way to add all the dependency for this library to work</summary>
    /// <param name="apiKey">API KEY FOR FIXER TO WORK</param>
    /// <param name="isPaidSubscription">If you have purchased a non free lisence then you should set it to <code>true</code>, By Default it is false, This is important because of SSL Certification. If you are using the free lisence then it will use the http protocol, if not it will use https</param>
    public static void AddFixer(this IServiceCollection serviceCollection, string apiKey, bool isPaidSubscription)
    {
        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey)) throw new NullReferenceException("Please provider proper api key for FIXER!!");

        serviceCollection.AddHttpClient();

        serviceCollection.AddScoped<IFixerClient>(x =>
        {
            return new FixerClient(x.GetRequiredService<HttpClient>(), apiKey, isPaidSubscription);
        });
    }
}