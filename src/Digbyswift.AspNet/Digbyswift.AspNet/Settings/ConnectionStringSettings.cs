using Microsoft.Extensions.Configuration;

namespace Digbyswift.AspNet.Settings;

public sealed class ConnectionStringSettings
{
    public const string SectionName = "ConnectionStrings";

    [ConfigurationKeyName("DefaultConnection")]
    public string? Default { get; set; }

    [ConfigurationKeyName("AzureStorageConnection")]
    public string? AzureStorage { get; set; }
}
