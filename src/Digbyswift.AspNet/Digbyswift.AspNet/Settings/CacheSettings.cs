using Microsoft.Extensions.Configuration;

namespace Digbyswift.AspNet.Settings;

public sealed class CacheSettings
{
    public const string SectionName = "Site:Caching";

    [ConfigurationKeyName("DataCachingEnabled")]
    public bool IsDataCachingEnabled { get; set; }

    [ConfigurationKeyName("OutputCachingEnabled")]
    public bool IsOutputCachingEnabled { get; set; }
}
