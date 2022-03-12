namespace Fixerr
{
    /// <summary>
    /// This class allows developers to set two fields
    /// <list type="number">
    /// <item>
    /// <para>ApiKey</para>
    /// <description>In order to use Fixer.io library, you will have to provide a api key. This is a mendartory requirements.</description>
    /// </item>
    /// <item>
    /// <para>IsPaidSubscription</para>
    /// <description>By default it will act as false. But if you are using the non free key, you should set this to <code>true</code></description>
    /// </item>
    /// </list>
    /// </summary>
    public sealed class FixerEnvironment
    {
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
        public static string ApiKey
        {
            set { _apiKey = value; }
            get
            {
                if (_apiKey is null)
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
        public static bool IsPaidSubscription { get; set; } = false;
    }
}
