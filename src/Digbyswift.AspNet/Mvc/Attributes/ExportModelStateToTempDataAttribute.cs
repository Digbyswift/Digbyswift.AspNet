using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Digbyswift.AspNet.Mvc.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class ExportModelStateToTempDataAttribute : ActionFilterAttribute
{
    public const string TempDataKey = "ExportModelStateToTempData";

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var controller = (Controller)context.Controller;

        if (!controller.ViewData.ModelState.IsValid && IsValidResult(context.Result))
        {
            controller.TempData[TempDataKey] = controller.ViewData.ModelState;
        }

        base.OnActionExecuted(context);
    }

    private static bool IsValidResult(IActionResult? result)
    {
        return result is RedirectResult or RedirectToRouteResult or JsonResult;
    }
}
