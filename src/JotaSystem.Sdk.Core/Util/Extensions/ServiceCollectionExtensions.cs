using Microsoft.Extensions.DependencyInjection;

namespace JotaSystem.Sdk.Core.Util.Extensions
{
    /// <summary>
    /// Extensões de IServiceCollection para registrar serviços do Core.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registra serviços principais do Core (ex.: MediatR).
        /// Use como ponto de partida; implementações concretas devem registrar repositórios, UoW, etc.
        /// </summary>
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Registra handlers do MediatR presentes neste assembly.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            // Aqui você pode registrar implementações default se quiser:
            // services.AddSingleton<IClock, SystemClock>();
            // services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            return services;
        }

        /// <summary>
        /// Encapsula a chamada de registro do Core para ficar centralizado.
        /// </summary>
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            return services.AddCoreServices();
        }
    }
}
