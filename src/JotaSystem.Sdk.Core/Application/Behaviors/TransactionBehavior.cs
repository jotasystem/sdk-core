using JotaSystem.Sdk.Core.Application.Abstractions;
using JotaSystem.Sdk.Core.CrossCutting;
using JotaSystem.Sdk.Core.Infrastructure.UnitOfWork;
using MediatR;

namespace JotaSystem.Sdk.Core.Application.Behaviors
{
    public sealed class TransactionBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork, ILoggerService logger, IDomainEventsDispatcher domainEventsDispatcher)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILoggerService _logger = logger;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher = domainEventsDispatcher;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Verifica se a requisição é um Command (evita transação em Queries)
            if (request is not ICommand<TResponse>) return await next();

            _logger.LogInformation($"Iniciando transação para Command '{typeof(TRequest).Name}'");
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var response = await next(); // Executa o Handler

                // Commit
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                // Dispara domain events
                await _domainEventsDispatcher.DispatchEventsAsync();

                _logger.LogInformation($"Transação para Command '{typeof(TRequest).Name}' concluída com sucesso.");
                return response;
            }
            catch (Exception ex)
            {
                //await _unitOfWork.RollbackAsync(cancellationToken);
                _logger.LogError(ex, $"Erro ao executar Command '{typeof(TRequest).Name}'. Transação revertida.");
                throw;
            }
        }
    }
}