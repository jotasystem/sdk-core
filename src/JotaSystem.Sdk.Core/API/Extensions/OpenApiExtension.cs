using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Reflection;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class OpenApiExtension
    {
        public enum OpenApiUiType
        {
            Swagger,
            Scalar
        }

        public static IServiceCollection AddCustomOpenApi(this IServiceCollection services, IConfiguration configuration, string title, string description)
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version;
            var apiVersion = $"v{version?.Major}.{version?.Minor}.{version?.Build}";
            var buildMode = configuration["BuildMode"];

            services.AddOpenApi("v1", options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;

                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = $"{title} [{buildMode}]",
                        Version = apiVersion,
                        Description = description,
                        Contact = new OpenApiContact
                        {
                            Name = "João Paulo",
                            Email = "contato@jotasystem.com",
                            Url = new Uri("https://jotasystem.com")
                        }
                    };

                    document.Components ??= new OpenApiComponents();
                    document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>
                    {
                        ["Bearer"] = new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            Scheme = "bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "Informe apenas o token JWT (sem o prefixo 'Bearer')."
                        }
                    };

                    foreach (var path in document.Paths.Values)
                    {
                        foreach (var operation in path.Operations?.Values!)
                        {
                            operation.Security ??= [];

                            operation.Security.Add(new OpenApiSecurityRequirement
                            {
                                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                            });
                        }
                    }

                    return Task.CompletedTask;
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCustomOpenApi(this IApplicationBuilder app, OpenApiUiType openApiUi)
        {
            var webApp = (WebApplication)app;

            webApp.MapOpenApi("/openapi/{documentName}.json");

            switch (openApiUi)
            {
                case OpenApiUiType.Swagger:
                    webApp.UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/openapi/v1.json", "Jota System API");
                        options.RoutePrefix = "swagger";
                        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                    });
                    break;
                case OpenApiUiType.Scalar:
                    webApp.MapScalarApiReference("scalar", scalar =>
                    {
                        scalar.WithTitle("Jota System API");
                        scalar.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                        scalar.WithOpenApiRoutePattern("/openapi/v1.json");
                    });
                    break;
                default:
                    break;
            }

            return app;
        }
    }
}