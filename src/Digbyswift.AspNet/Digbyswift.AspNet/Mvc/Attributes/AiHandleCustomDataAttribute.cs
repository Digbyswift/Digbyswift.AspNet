using Digbyswift.Http.Extensions;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace Digbyswift.AspNet.Mvc.Attributes;

public sealed class AiHandleCustomDataAttribute : IAsyncActionFilter
{
    private const string AjaxKey = "IsAjax";
    private const string UaKey = "UserAgent";
    private const string ReferrerKey = "ReferringUrl";
    private const string TrackingKey = "Extended details";

    private TelemetryClient? _telemetryClient;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _telemetryClient ??= context.HttpContext.RequestServices.GetService<TelemetryClient>();

        var request = context.HttpContext.Request;
        var dict = new Dictionary<string, string>
        {
            { AjaxKey, request.IsAjaxRequest().ToString() },
        };

        if (request.Headers.TryGetValue(HeaderNames.UserAgent, out var userAgents) && userAgents.Count > 0)
        {
            dict.Add(UaKey, userAgents.ToString());
        }

        if (request.Headers.TryGetValue(HeaderNames.Referer, out var referrer) && referrer.Count > 0)
        {
            dict.Add(ReferrerKey, referrer.ToString());
        }

        _telemetryClient?.TrackTrace(TrackingKey, SeverityLevel.Information, dict);

        await next();
    }
}
