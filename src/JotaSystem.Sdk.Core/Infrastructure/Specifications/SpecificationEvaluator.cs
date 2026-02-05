using JotaSystem.Sdk.Core.Application.Specifications;
using Microsoft.EntityFrameworkCore;

namespace JotaSystem.Sdk.Core.Infrastructure.Specifications
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> specification)
            where TEntity : class
        {
            var query = inputQuery;

            // 🔹 Criteria
            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            // 🔹 Include simples
            foreach (var include in specification.Includes)
                query = query.Include(include);

            // 🔹 Include com ThenInclude
            foreach (var include in specification.IncludeExpressions)
                query = include(query);

            // 🔹 Ordenação
            if (specification.OrderBy is not null)
                query = specification.OrderBy(query);
            else if (specification.OrderByDescending is not null)
                query = specification.OrderByDescending(query);

            // 🔹 Paginação
            if (specification.IsPagingEnabled)
            {
                if (specification.Skip.HasValue)
                    query = query.Skip(specification.Skip.Value);

                if (specification.Take.HasValue)
                    query = query.Take(specification.Take.Value);
            }

            return query;
        }
    }
}