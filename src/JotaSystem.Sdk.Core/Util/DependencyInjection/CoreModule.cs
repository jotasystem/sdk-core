using JotaSystem.Sdk.Core.Util.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotaSystem.Sdk.Core.Util.DependencyInjection
{
    /// <summary>
    /// Ponto central de composição (composition root) do Core SDK.
    /// Chamado pelas aplicações que desejam usar o Core.
    /// </summary>
    public static class CoreModule
    {
        /// <summary>
        /// Registra os serviços base do Core no container de DI.
        /// </summary>
        public static IServiceCollection RegisterCore(this IServiceCollection services)
        {
            // Registrar serviços e módulos do Core
            services.AddCoreModule();

            // Retornar a coleção para encadeamento
            return services;
        }
    }
}
