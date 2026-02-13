using JotaSystem.Sdk.Core.Application.Specifications;
using JotaSystem.Sdk.Core.Domain.Entities;
using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Representa uma unidade de trabalho (Unit of Work) 
    /// responsável por coordenar operações de persistência e transações de forma consistente.
    /// </summary>
    public interface IUnitOfWork : ITransaction, IAsyncDisposable
    {
        /// <summary>
        /// Confirma todas as alterações pendentes no contexto de persistência atual.
        /// </summary>
        /// <param name="cancellationToken">Token opcional para cancelamento da operação.</param>
        /// <returns>O número de registros afetados.</returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        Task<TEntity?> GetForUpdateAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Specification<TEntity> specification, CancellationToken cancellationToken = default)
            where TEntity : class, IAggregateRoot;

        void Add<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;
        void Update<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;
        void Remove<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;
        void HardRemove<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;
    }
}