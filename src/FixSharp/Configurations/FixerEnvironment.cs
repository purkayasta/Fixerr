// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

namespace Fixerr.Configurations;
internal sealed class FixerEnvironment
{
    internal const string httpClientName = "FixerHttpClient";

    private const string _baseUrl = "data.fixer.io/api/";
    internal static Uri BaseUrl
    {
        get
        {
            return IsPaidSubscription ? new Uri($"https://{_baseUrl}") : new Uri($"http://{_baseUrl}");
        }
    }
    internal static string FixerDateFormat { get; } = "yyyy-MM-dd";

    private static string _apiKey = string.Empty;

    /// <summary>
    /// This is where you should set your fixer's api key.
    /// </summary>
    internal static string ApiKey
    {
        set { _apiKey = value; }
        get
        {
            if (string.IsNullOrEmpty(_apiKey) || string.IsNullOrWhiteSpace(_apiKey))
                throw new NullReferenceException($"{nameof(ApiKey)} is empty! Please Set the appropiate value");
            return _apiKey;
        }
    }

    /// <summary>
    /// If you have purchased a non free lisence then you should set it to <code>true</code>
    /// <para>This is important because of SSL Certification. </para>
    /// <para>If you are using the free lisence then it will use the http protocol, if not it will use https</para>
    /// </summary>
    /// <returns>a boolean value indicating the status</returns>
    internal static bool IsPaidSubscription { get; set; } = false;
}
