using JotaSystem.Sdk.Core.Application.Results;
using JotaSystem.Sdk.Core.CrossCutting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class ControllersExtension
    {
        public static IServiceCollection AddApiControllersWithModelState(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .SelectMany(x =>
                            x.Value!.Errors.Select(e =>
                                new Notification(
                                    field: x.Key,
                                    key: "ValidationError",
                                    message: [e.ErrorMessage]
                                )
                            )
                        )
                        .ToList();

                    var result = ResultFactory.BadRequest<object>(
                        message: "Bad Request",
                        errors: errors
                    );

                    return new BadRequestObjectResult(result);
                };
            });

            return services;
        }
    }
}