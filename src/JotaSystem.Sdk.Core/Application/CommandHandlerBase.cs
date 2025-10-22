using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotaSystem.Sdk.Core.Application
{
    /// <summary>
    /// Classe base para handlers de comandos/requests, aproveitando MediatR.
    /// </summary>
    /// <typeparam name="TRequest">Tipo do request</typeparam>
    /// <typeparam name="TResponse">Tipo da resposta</typeparam>
    public abstract class CommandHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Implementação obrigatória do handler.
        /// </summary>
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}