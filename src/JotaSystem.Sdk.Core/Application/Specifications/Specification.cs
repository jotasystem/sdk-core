using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Application.Specifications
{
    public abstract class Specification<TEntity>
    {
        // 🔹 Filtro principal
        public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }

        // 🔹 Include simples: x => x.Navigation
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();

        // 🔹 Include avançado: Include + ThenInclude
        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> IncludeExpressions { get; } = new();

        // 🔹 Ordenação
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; protected set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderByDescending { get; protected set; }

        // 🔹 Paginação (opcional)
        public int? Skip { get; protected set; }
        public int? Take { get; protected set; }
        public bool IsPagingEnabled => Skip.HasValue || Take.HasValue;

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}