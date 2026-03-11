using Microsoft.AspNetCore.Builder;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class PipelineExtensions
    {
        public static WebApplication UseApiDefaults(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseCors(CorsExtension.DefaultCorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}