using Microsoft.Extensions.DependencyInjection;

namespace Fixerr.Configurations;

public static class FixerExtensions
{
    #region Microsoft DI

    /// <summary>
    /// Add fixer through options pattern
    /// {
    ///     "ApiKey":"",
    ///     "IsPaidSubscription":""
    /// }
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="optionName">FixerOptions</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddFixer(this IServiceCollection serviceCollection, string optionName)
    {
        if (string.IsNullOrEmpty(optionName) || string.IsNullOrWhiteSpace(optionName))
            throw new ArgumentNullException(nameof(optionName));

        AddHttpClient(serviceCollection);

        serviceCollection.AddOptions<FixerOptions>(optionName);
    }

    /// <summary>
    /// Add fixer using apikey and subscription flag for https
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="apiKey"></param>
    /// <param name="isPaidSubscription">If you have purchased a non free license then you should set it to <code>true</code>,
    /// By Default it is false, This is important because of SSL Certification. If you are using the free license then it will use the
    /// http protocol, if not it will use https</param>
    /// <exception cref="NullReferenceException"></exception>
    public static void AddFixer(this IServiceCollection serviceCollection, string apiKey, bool isPaidSubscription)
    {
        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey)) 
            throw new NullReferenceException("Please provider proper api key for FIXER!!");

        AddHttpClient(serviceCollection);

        serviceCollection.Configure<FixerOptions>(option =>
        {
            option.ApiKey = apiKey;
            option.IsPaidSubscription = isPaidSubscription;
        });
    }

    #endregion


    private static void AddHttpClient(IServiceCollection serviceCollection) 
        => serviceCollection.AddHttpClient(FixerEnvironment.HttpClientName);
}
