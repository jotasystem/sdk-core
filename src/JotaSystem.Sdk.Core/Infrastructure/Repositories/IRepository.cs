using JotaSystem.Sdk.Core.Domain.Entities;

namespace JotaSystem.Sdk.Core.Infrastructure.Repositories
{
    /// <summary>
    /// Interface genérica de repositório base
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>  
    public interface IRepository<TEntity> 
        where TEntity : class, IAggregateRoot
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}