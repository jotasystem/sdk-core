using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace JotaSystem.Sdk.Core.Application.Results
{
    public class Result
    {
        public bool Success { get; }
        public int StatusCode { get; }
        public string Message { get; }
        public string? TraceId { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Notification>? Errors { get; } = [];

        protected Result(bool success, int statusCode, string message, string? traceId, List<Notification>? errors)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            TraceId = traceId;
            Errors = errors;
        }

        public static Result Ok(int statusCode = StatusCodes.Status200OK, string message = "Ok", string? traceId = null)
            => new(true, statusCode, message, traceId, null);

        public static Result Fail(int statusCode = StatusCodes.Status500InternalServerError, string message = "Fail", string? traceId = null, List<Notification>? errors = null)
            => new(false, statusCode, message, traceId, errors);
    }

    public class Result<T> : Result
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; }

        private Result(T? data, int statusCode, string message, string? traceId, List<Notification>? errors = null)
            : base(true, statusCode, message, traceId, errors)
        {
            Data = data;
        }

        public static Result<T> Ok(T data, int statusCode = StatusCodes.Status200OK, string message = "Success", string? traceId = null)
            => new(data, statusCode, message, traceId);

        public static new Result<T> Fail(int statusCode = StatusCodes.Status500InternalServerError, string message = "Fail", string? traceId = null, List<Notification>? errors = null)
            => new(default!, statusCode, message, traceId, errors ?? []);
    }
}