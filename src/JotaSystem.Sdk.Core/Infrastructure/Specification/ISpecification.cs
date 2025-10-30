using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Infrastructure.Specification
{
    /// <summary>
    /// Abstração de especificação para queries.
    /// </summary>
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
    }
}