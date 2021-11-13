using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Alza_API
{
    /// <summary>
    /// Input parameters validation
    /// </summary>
    public class ValidateProductsParametersAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Override OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                string id = context.ActionArguments["id"] as string;

                if (!Guid.TryParse(id, out Guid guid))
                {
                    context.Result = new BadRequestObjectResult("Invalid product ID.");
                }
            }
        }
    }
}
