using JotaSystem.Sdk.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace JotaSystem.Sdk.Core.API.Extensions
{
    public static class LocalizationExtension
    {
        public static IServiceCollection AddCustomLocalization(this IServiceCollection services, params string[] cultures)
        {
            var sourceCultures = (cultures is { Length: > 0 }) ? cultures : ["pt-BR"];

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = sourceCultures.Select(c => new CultureInfo(c)).ToList();
                var defaultCulture = supportedCultures[0];

                LanguageProvider.SetDefault(LanguageProvider.FromCulture(defaultCulture));

                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders =
                [
                    new AcceptLanguageHeaderRequestCultureProvider(),
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                ];
            });

            return services;
        }

        public static IApplicationBuilder UseCustomLocalization(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices
                .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;

            app.UseRequestLocalization(options);

            // mantém seu LanguageProvider em sincronia com a cultura da request
            app.Use(async (context, next) =>
            {
                var feature = context.Features.Get<IRequestCultureFeature>();
                if (feature != null)
                    LanguageProvider.SetDefault(LanguageProvider.FromCulture(feature.RequestCulture.Culture));

                await next();
            });

            return app;
        }
    }
}