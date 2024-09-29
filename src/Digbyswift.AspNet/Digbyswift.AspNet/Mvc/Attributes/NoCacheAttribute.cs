using Digbyswift.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Digbyswift.AspNet.Mvc.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class NoCacheAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.SetNoCacheHeaders();

        base.OnResultExecuting(context);
    }
}
