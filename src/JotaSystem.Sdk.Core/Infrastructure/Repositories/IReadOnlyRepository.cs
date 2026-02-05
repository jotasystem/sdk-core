using JotaSystem.Sdk.Core.Application.Specifications;
using JotaSystem.Sdk.Core.CrossCutting.Models;
using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Infrastructure.Repositories
{
    /// <summary>
    /// Interface genérica de repositório somente leitura
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(long id, bool disableTracking = true, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByExternalIdAsync(Guid externalId, bool disableTracking = true, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default);

        Task<IList<TEntity>> GetAsync(Specification<TEntity>? specification = null, CancellationToken cancellationToken = default);
        Task<PaginatedList<TEntity>> GetPagedAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    }
}