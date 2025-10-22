namespace JotaSystem.Sdk.Core.Infrastructure
{
    /// <summary>
    /// Representa uma transação genérica
    /// </summary>
    public interface ITransaction : IAsyncDisposable
    {
        /// <summary>
        /// Confirma (commit) a transação
        /// </summary>
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Desfaz (rollback) a transação
        /// </summary>
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}