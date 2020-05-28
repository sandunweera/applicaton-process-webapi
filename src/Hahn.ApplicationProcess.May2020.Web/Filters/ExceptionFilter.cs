using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.May2020.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            var problemDetails = new ProblemDetails
            {
                Title = context.Exception.GetType().Name,
                Detail = context.Exception.Message
            };

            switch (context.Exception)
            {
                case UnauthorizedAccessException _:
                    context.Result = new ObjectResult(problemDetails) {StatusCode = (int) HttpStatusCode.Unauthorized};
                    break;
                case TimeoutException _:
                    context.Result = new ObjectResult(problemDetails)
                        {StatusCode = (int) HttpStatusCode.RequestTimeout};
                    break;
                default:
                    context.Result = new ObjectResult(problemDetails)
                        {StatusCode = (int) HttpStatusCode.InternalServerError};
                    break;
            }
        }
    }
}