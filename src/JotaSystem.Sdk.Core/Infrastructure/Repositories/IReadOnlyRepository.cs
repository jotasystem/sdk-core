using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Infrastructure.Repositories
{
    /// <summary>
    /// Interface genérica de repositório somente leitura
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        // Consultas simples
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default);

        // Consultas individuais
        Task<TEntity?> GetByIdAsync(
            long id,
            bool disableTracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            CancellationToken cancellationToken = default);

        Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? order = null,
            bool disableTracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            CancellationToken cancellationToken = default);

        // Consultas de lista
        Task<IList<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? order = null,
            bool disableTracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            CancellationToken cancellationToken = default);

        // Paginação
        //Task<PagedModel<TEntity>> GetAllWithPaginationAsync(
        //    int page,
        //    int pageSize = 10,
        //    Expression<Func<TEntity, bool>>? filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? order = null,
        //    bool disableTracking = true,
        //    Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        //    CancellationToken cancellationToken = default);
    }
}