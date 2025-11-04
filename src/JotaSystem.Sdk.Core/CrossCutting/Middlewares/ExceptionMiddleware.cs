using JotaSystem.Sdk.Common.Extensions.Json;
using JotaSystem.Sdk.Core.Application.Results;
using JotaSystem.Sdk.Core.CrossCutting.Exceptions;
using JotaSystem.Sdk.Core.CrossCutting.Logging;
using Microsoft.AspNetCore.Http;

namespace JotaSystem.Sdk.Core.CrossCutting.Middlewares
{
    public class ExceptionMiddleware(ILoggerService logger) : IMiddleware
    {
        private readonly ILoggerService _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized && !context.Response.HasStarted)
                    throw HttpException.Unauthorized("Unauthorized");

                else if (context.Response.StatusCode == StatusCodes.Status403Forbidden && !context.Response.HasStarted)
                    throw HttpException.Forbidden("Forbidden");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UnexpectedError");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                HttpException httpEx => httpEx.StatusCode,
                DomainException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var title = exception is CustomException custom ? custom.Title : "ServerError";
            var message = exception.Message;
            var errors = (exception as HttpException)?.Errors;

            object result = statusCode switch
            {
                StatusCodes.Status400BadRequest => ResultFactory.BadRequest<object>(message, errors),
                StatusCodes.Status401Unauthorized => ResultFactory.Unauthorized<object>(message, errors),
                StatusCodes.Status403Forbidden => ResultFactory.Forbidden<object>(message, errors),
                StatusCodes.Status404NotFound => ResultFactory.NotFound<object>(message, errors),
                StatusCodes.Status422UnprocessableEntity => ResultFactory.UnprocessableEntity<object>(message, errors),
                StatusCodes.Status500InternalServerError => ResultFactory.InternalServerError<object>(message, errors),
                _ => ResultFactory.InternalServerError<object>(message)
            };

            var response = JsonExtension.ToJson(result);

            if (!context.Response.HasStarted)
            {
                context.Response.Headers.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(response);
            }
        }
    }
}