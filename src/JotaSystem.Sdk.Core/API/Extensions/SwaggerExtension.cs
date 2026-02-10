using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration, string title, string description)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var version = Assembly.GetEntryAssembly()?.GetName().Version;

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{title} [{configuration["BuildMode"]}]",
                    Version = $"v{version?.Major}.{version?.Minor}.{version?.Build}",
                    Description = description,
                    Contact = new OpenApiContact
                    {
                        Name = "João Paulo",
                        Email = "contato@jotasystem.com",
                        Url = new Uri("https://jotasystem.com")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Informe apenas o token JWT (sem o prefixo 'Bearer')."
                });

                c.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, doc)] = []
                });

                var xml = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xml);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(s => s.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jota System API v1");
                c.RoutePrefix = "swagger";
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
