namespace JotaSystem.Sdk.Core.Infrastructure
{
    /// <summary>
    /// Representa uma unidade de trabalho genérica
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Salva todas as alterações pendentes
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Inicia uma transação genérica
        /// </summary>
        Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}