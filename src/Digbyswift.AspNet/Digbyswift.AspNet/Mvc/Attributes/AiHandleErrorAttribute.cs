using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Digbyswift.AspNet.Mvc.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class AiHandleErrorAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext filterContext)
    {
        filterContext.HttpContext.RequestServices.GetService<TelemetryClient>()?.TrackException(filterContext.Exception);
    }
}
