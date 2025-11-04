using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Http;

namespace JotaSystem.Sdk.Core.Application.Results
{
    public class Result<T>
    {
        public bool Success { get; }
        public int StatusCode { get; }
        public string Message { get; }
        public T Value { get; }
        public List<Notification> Errors { get; } = [];

        protected Result(T value, bool success, string message, List<Notification> errors, int statusCode)
        {
            Value = value;
            Success = success;
            Message = message;
            Errors = errors ?? [];
            StatusCode = statusCode != 0 ? statusCode : success ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError;
        }

        public static Result<T> Ok(T value, string message = "", int statusCode = StatusCodes.Status200OK)
            => new(value, true, message, [], statusCode);

        public static Result<T> Fail(string message, int statusCode, List<Notification>? errors = null)
            => new(default!, false, message, errors ?? [], statusCode);
    }
}