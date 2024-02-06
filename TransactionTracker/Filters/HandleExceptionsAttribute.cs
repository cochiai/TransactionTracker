using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TransactionTracker.Filters
{
    public class HandleExceptionsAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<HandleExceptionsAttribute> _logger;

        public HandleExceptionsAttribute(ILogger<HandleExceptionsAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            
            _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);
            context.Result = new RedirectToRouteResult(new RouteValueDictionary {{ "action", "Error" }, { "controller", "Home" }});
            context.ExceptionHandled = true;
            
        }
    }
}
