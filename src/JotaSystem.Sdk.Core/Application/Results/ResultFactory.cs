using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace JotaSystem.Sdk.Core.Application.Results
{
    public static class ResultFactory
    {
        private static string? GetTraceId() => Activity.Current?.Id;

        // SUCCESS
        public static Result<T> Success<T>(T data, string? message = null, int statusCode = StatusCodes.Status200OK)
            => Result<T>.Ok(data, statusCode, message ?? "Success", GetTraceId());

        public static Result Success(string? message = null, int statusCode = StatusCodes.Status200OK)
            => Result.Ok(statusCode, message ?? "Success", GetTraceId());

        // ERROR
        public static Result BadRequest(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status400BadRequest, message ?? "Bad Request", GetTraceId(), errors);

        public static Result Unauthorized(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status401Unauthorized, message ?? "Unauthorized", GetTraceId(), errors);

        public static Result Forbidden(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status403Forbidden, message ?? "Forbidden", GetTraceId(), errors);

        public static Result NotFound(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status404NotFound, message ?? "Not Found", GetTraceId(), errors);

        public static Result Conflict(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status409Conflict, message ?? "Conflict", GetTraceId(), errors);

        public static Result InternalServerError(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status500InternalServerError, message ?? "Internal Server Error", GetTraceId(), errors);

        public static Result Custom(int statusCode, string message, List<Notification>? errors = null)
            => Result.Fail(statusCode, message, GetTraceId(), errors);
    }
}