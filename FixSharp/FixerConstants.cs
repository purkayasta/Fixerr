namespace FixSharp
{
    public sealed class FixerConstants
    {
        public static Uri BaseUrl { get; } = new Uri("https://data.fixer.io/api/");
        public static string ApiKey { get; set; }
    }
}
