using Digbyswift.AspNet.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digbyswift.AspNet.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConnectionStrings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ConnectionStringSettings>(config.GetSection(ConnectionStringSettings.SectionName));

        return services;
    }

    public static IServiceCollection AddEnvironmentSettings(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(new EnvironmentSettings(config));

        return services;
    }

    public static IServiceCollection AddEmailSettings(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(new EmailSettings(config));

        return services;
    }

    public static IServiceCollection AddCacheSettings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<CacheSettings>(config.GetSection(CacheSettings.SectionName));

        return services;
    }

    public static IServiceCollection AddRecaptchaSettings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<RecaptchaSettings>(config.GetSection(RecaptchaSettings.SectionName));

        return services;
    }

    public static IServiceCollection AddGhostInspectorSettings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<GhostInspectorSettings>(config.GetSection(GhostInspectorSettings.SectionName));

        return services;
    }
}
