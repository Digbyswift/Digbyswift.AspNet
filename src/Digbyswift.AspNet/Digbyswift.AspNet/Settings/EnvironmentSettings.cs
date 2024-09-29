using Digbyswift.Core.Constants;
using Microsoft.Extensions.Configuration;

namespace Digbyswift.AspNet.Settings;

public class EnvironmentSettings
{
    public string Value { get; }
    public string? SiteBaseUrl { get; }

    public EnvironmentSettings(IConfiguration config)
    {
        Value = config.GetValue<string>("Site:Environment", "Local")!;
        SiteBaseUrl = config.GetValue<string>("Site:BaseUrl");
    }

    public bool IsLocal() => Value == AppEnvironment.Local;

    public virtual bool IsDeployment()
    {
        return (Value == AppEnvironment.ProductionDeploy ||
                Value == AppEnvironment.ProductionCmsDeploy ||
                Value == AppEnvironment.StagingDeploy ||
                Value == AppEnvironment.StagingCmsDeploy);
    }

    /// <summary>
    /// Returns true if the CMS is accessible, including local and deployment environments.
    /// </summary>
    public bool IsCms()
    {
        return (Value == AppEnvironment.Local ||
                Value == AppEnvironment.ProductionCms ||
                Value == AppEnvironment.ProductionCmsDeploy ||
                Value == AppEnvironment.StagingCms ||
                Value == AppEnvironment.StagingCmsDeploy);
    }

    public virtual bool IsStaging()
    {
        return (Value == AppEnvironment.Staging ||
                Value == AppEnvironment.StagingDeploy ||
                Value == AppEnvironment.StagingCms ||
                Value == AppEnvironment.StagingCmsDeploy);
    }

    public virtual bool IsProduction()
    {
        return (Value == AppEnvironment.Production ||
                Value == AppEnvironment.ProductionDeploy ||
                Value == AppEnvironment.ProductionCms ||
                Value == AppEnvironment.ProductionCmsDeploy);
    }
}
