using Microsoft.Extensions.DependencyInjection;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class CorsExtension
    {
        public const string DefaultCorsPolicy = "DefaultCorsPolicy";

        public static IServiceCollection AddDefaultCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicy, policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });

            return services;
        }
    }
}