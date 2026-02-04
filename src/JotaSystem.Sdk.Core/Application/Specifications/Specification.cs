using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Application.Specifications
{
    public abstract class Specification<TEntity>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; } = [];
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; protected set; }
    }
}