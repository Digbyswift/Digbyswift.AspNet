#pragma warning disable SA1402
using Microsoft.Extensions.Configuration;

namespace Digbyswift.AspNet.Settings;

public sealed class RecaptchaSettings
{
    public const string SectionName = "Recaptcha";

    [ConfigurationKeyName("v2")]
    public RecaptchaVersionSettings? V2 { get; set; }

    [ConfigurationKeyName("v3")]
    public RecaptchaVersionSettings? V3 { get; set; }

    public IEnumerable<string> BotWhitelist { get; set; } = Enumerable.Empty<string>();
}

public sealed class RecaptchaVersionSettings
{
    [ConfigurationKeyName("Enabled")]
    public bool IsEnabled { get; set; }

    public string? PublicKey { get; set; }
    public string? SecretKey { get; set; }
    public decimal ThresholdScore { get; set; } = 0.5m;
}
