using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net;
using Microsoft.AspNetCore.Http;
using System;

namespace TransactionTrackerService.Filters
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
            context.Result = new ObjectResult(context.Exception.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            context.ExceptionHandled = true;

        }
    }
}
