using JotaSystem.Sdk.Core.Domain.Entities;
using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Infrastructure.Repositories
{
    /// <summary>
    /// Interface genérica de repositório base
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>  
    public interface IRepository<TEntity> 
        where TEntity : class, IAggregateRoot
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void HardRemove(TEntity entity);
    }
}