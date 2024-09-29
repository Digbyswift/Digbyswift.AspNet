using System.Net;
using Digbyswift.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Digbyswift.AspNet.Mvc.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class InternalReferrerOnlyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var referrer = context.HttpContext.Request.GetSameHostReferrer();
        if (referrer == null)
        {
            context.Result = new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }
}
