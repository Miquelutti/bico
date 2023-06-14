using Fatec.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ProjectFatec.WebApi.Filters
{
    public class ExecutionExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExecutionExceptionFilter> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ExecutionExceptionFilter(
            ILogger<ExecutionExceptionFilter> logger,
            IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;
            HttpStatusCode statusCode;

            if (_hostingEnvironment.EnvironmentName == Environments.Development)
                message = context.Exception.ToString();

            switch (context.Exception)
            {
                case IsValidationException _:
                    _logger.LogWarning(context.Exception, $"{context.Exception.Message}-{context.Exception.StackTrace}");
                    statusCode = HttpStatusCode.UnprocessableEntity;
                    break;
                case NotFoundException _:
                    _logger.LogWarning(context.Exception, $"{context.Exception.Message}-{context.Exception.StackTrace}");
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ConflictException _:
                    _logger.LogWarning(context.Exception, $"{context.Exception.Message}-{context.Exception.StackTrace}");
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case NotAuthorizedException _:
                    _logger.LogWarning(context.Exception, $"{context.Exception.Message}-{context.Exception.StackTrace}");
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                default:
                    _logger.LogError(context.Exception, $"{context.Exception.Message}-{context.Exception.StackTrace}");
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.HttpContext.Response.Headers.Add("traceId", context.HttpContext.TraceIdentifier);

            context.Result = new ObjectResult(message)
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
