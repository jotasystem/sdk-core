using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace JotaSystem.Sdk.Core.Application.Results
{
    public static class ResultFactory
    {
        private static string? GetTraceId() => Activity.Current?.Id;

        // SUCCESS (COM DATA)
        public static Result<T> Success<T>(T data, string? message = null, int statusCode = StatusCodes.Status200OK)
            => Result<T>.Ok(data, statusCode, message ?? "Success", GetTraceId());

        // SUCCESS SEM DATA
        public static Result Success(string? message = null, int statusCode = StatusCodes.Status200OK)
            => Result.Ok(statusCode, message ?? "Success", GetTraceId());


        // ERRO TIPADO (Result<T>)
        public static Result<T> BadRequest<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status400BadRequest, message ?? "Bad Request", GetTraceId(), errors);

        public static Result<T> Unauthorized<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status401Unauthorized, message ?? "Unauthorized", GetTraceId(), errors);

        public static Result<T> Forbidden<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status403Forbidden, message ?? "Forbidden", GetTraceId(), errors);

        public static Result<T> NotFound<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status404NotFound, message ?? "Not Found", GetTraceId(), errors);

        public static Result<T> MethodNotAllowed<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status405MethodNotAllowed, message ?? "Method Not Allowed", GetTraceId(), errors);

        public static Result<T> Conflict<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status409Conflict, message ?? "Conflict", GetTraceId(), errors);

        public static Result<T> UnprocessableEntity<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status422UnprocessableEntity, message ?? "Unprocessable Entity", GetTraceId(), errors);

        public static Result<T> InternalServerError<T>(string? message = null, List<Notification>? errors = null)
            => Result<T>.Fail(StatusCodes.Status500InternalServerError, message ?? "Internal Server Error", GetTraceId(), errors);

        public static Result<T> Custom<T>(int statusCode, string message, List<Notification>? errors = null)
            => Result<T>.Fail(statusCode, message, GetTraceId(), errors);

        // ERROR SEM TIPO (Result)
        public static Result BadRequest(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status400BadRequest, message ?? "Bad Request", GetTraceId(), errors);

        public static Result Unauthorized(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status401Unauthorized, message ?? "Unauthorized", GetTraceId(), errors);

        public static Result Forbidden(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status403Forbidden, message ?? "Forbidden", GetTraceId(), errors);

        public static Result NotFound(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status404NotFound, message ?? "Not Found", GetTraceId(), errors);

        public static Result MethodNotAllowed(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status405MethodNotAllowed, message ?? "Method Not Allowed", GetTraceId(), errors);

        public static Result Conflict(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status409Conflict, message ?? "Conflict", GetTraceId(), errors);

        public static Result UnprocessableEntity(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status422UnprocessableEntity, message ?? "Unprocessable Entity", GetTraceId(), errors);

        public static Result InternalServerError(string? message = null, List<Notification>? errors = null)
            => Result.Fail(StatusCodes.Status500InternalServerError,  message ?? "Internal Server Error", GetTraceId(), errors);

        public static Result Custom(int statusCode, string message, List<Notification>? errors = null)
            => Result.Fail(statusCode, message, GetTraceId(), errors);
    }
}