namespace Digbyswift.AspNet.Settings;

public sealed class SmtpOptions
{
    internal const string SectionName = "Site:Email:Smtp";

    public string? From { get; set; }
    public string? Host { get; set; }
    public int? Port { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
