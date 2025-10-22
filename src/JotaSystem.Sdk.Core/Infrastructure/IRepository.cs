namespace JotaSystem.Sdk.Core.Infrastructure
{
    /// <summary>
    /// Interface genérica de repositório base
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>  
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        // CRUD
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(long id, bool softDelete = true, CancellationToken cancellationToken = default);
    }
}