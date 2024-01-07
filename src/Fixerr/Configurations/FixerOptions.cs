namespace Fixerr.Configurations;

public sealed class FixerOptions
{
    public string ApiKey { get; set; } = string.Empty;
    public bool IsPaidSubscription { get; set; } = false;
}