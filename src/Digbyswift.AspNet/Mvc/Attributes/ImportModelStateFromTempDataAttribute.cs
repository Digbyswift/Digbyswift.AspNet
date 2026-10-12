using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Digbyswift.AspNet.Mvc.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class ImportModelStateFromTempDataAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var controller = (Controller)context.Controller;

        if (controller.TempData[ExportModelStateToTempDataAttribute.TempDataKey] is ModelStateDictionary modelState)
        {
            // Only import if we are viewing
            if (context.Result is ViewResult or PartialViewResult)
            {
                controller.ViewData.ModelState.Merge(modelState);
            }
            else
            {
                // Otherwise remove it
                controller.TempData.Remove(ExportModelStateToTempDataAttribute.TempDataKey);
            }
        }

        base.OnActionExecuted(context);
    }
}
