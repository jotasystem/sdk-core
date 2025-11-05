using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Http;

namespace JotaSystem.Sdk.Core.CrossCutting.Exceptions
{
    public class HttpException(int statusCode, string title, string message, List<Notification>? errors = null) 
        : CustomException(title, message)
    {
        public int StatusCode { get; } = statusCode;
        public List<Notification>? Errors { get; } = errors;


        public static HttpException BadRequest(string message, List<Notification>? errors = null)
            => new(StatusCodes.Status400BadRequest, "BadRequest", message, errors);

        public static HttpException Unauthorized(string message)
            => new(StatusCodes.Status401Unauthorized, "Unauthorized", message);

        public static HttpException Forbidden(string message)
            => new(StatusCodes.Status403Forbidden, "Forbidden", message);

        public static HttpException NotFound(string message)
            => new(StatusCodes.Status404NotFound, "NotFound", message);

        public static HttpException MethodNotAllowed(string message)
            => new(StatusCodes.Status405MethodNotAllowed, "MethodNotAllowed", message);

        public static HttpException Conflict(string message)
            => new(StatusCodes.Status409Conflict, "Conflict", message);

        public static HttpException UnprocessableEntity(List<Notification> errors)
            => new(StatusCodes.Status422UnprocessableEntity, "ValidationFailure", "ValidationError", errors);

        public static HttpException InternalServerError(string? message = null, List<Notification>? errors = null)
            => new(StatusCodes.Status500InternalServerError, "InternalServerError", message ?? "Internal Server Error", errors);

        public static HttpException Custom(int statusCode, string title, string message, List<Notification>? errors = null)
            => new(statusCode, title, message, errors);
    }
}