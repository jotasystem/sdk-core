namespace JotaSystem.Sdk.Core.Infrastructure
{
    /// <summary>
    /// Representa uma unidade de trabalho (Unit of Work) 
    /// responsável por coordenar operações de persistência e transações de forma consistente.
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Confirma todas as alterações pendentes no contexto de persistência atual.
        /// </summary>
        /// <param name="cancellationToken">Token opcional para cancelamento da operação.</param>
        /// <returns>O número de registros afetados.</returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        /// Inicia uma transação explícita no contexto de persistência.
        /// </summary>
        /// <param name="cancellationToken">Token opcional para cancelamento da operação.</param>
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Confirma a transação atual, persistindo definitivamente as alterações realizadas.
        /// </summary>
        /// <param name="cancellationToken">Token opcional para cancelamento da operação.</param>
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Reverte todas as operações realizadas dentro da transação atual.
        /// </summary>
        /// <param name="cancellationToken">Token opcional para cancelamento da operação.</param>
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}