using Microsoft.AspNetCore.Builder;
using Serilog;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog();

            return builder;
        }

        public static WebApplication UseSerilog(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            return app;
        }
    }
}