using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace JotaSystem.Sdk.Core.Application.Results
{
    public static class ResultFactory
    {
        private static string? GetTraceId() => Activity.Current?.Id;

        public static Result<T> Success<T>(T value, string? message = null, int statusCode = StatusCodes.Status200OK)
        {
            message ??= "Success";
            return Result<T>.Ok(value, message, statusCode, GetTraceId());
        }

        public static Result<T> BadRequest<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Bad Request";
            return Result<T>.Fail(message, StatusCodes.Status400BadRequest, errors, GetTraceId());
        }

        public static Result<T> Unauthorized<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Unauthorized";
            return Result<T>.Fail(message, StatusCodes.Status401Unauthorized, errors, GetTraceId());
        }

        public static Result<T> Forbidden<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Forbidden";
            return Result<T>.Fail(message, StatusCodes.Status403Forbidden, errors, GetTraceId());
        }

        public static Result<T> NotFound<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Not Found";
            return Result<T>.Fail(message, StatusCodes.Status404NotFound, errors, GetTraceId());
        }

        public static Result<T> MethodNotAllowed<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Method Not Allowed";
            return Result<T>.Fail(message, StatusCodes.Status405MethodNotAllowed, errors, GetTraceId());
        }

        public static Result<T> Conflict<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Conflict";
            return Result<T>.Fail(message, StatusCodes.Status409Conflict, errors, GetTraceId());
        }

        public static Result<T> UnprocessableEntity<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Unprocessable Entity";
            return Result<T>.Fail(message, StatusCodes.Status422UnprocessableEntity, errors, GetTraceId());
        }

        public static Result<T> InternalServerError<T>(string? message = null, List<Notification>? errors = null)
        {
            message ??= "Internal Server Error";
            return Result<T>.Fail(message, StatusCodes.Status500InternalServerError, errors, GetTraceId());
        }

        public static Result<T> Custom<T>(int statusCode, string message, List<Notification>? errors = null)
            => Result<T>.Fail(message, statusCode, errors, GetTraceId());
    }
}