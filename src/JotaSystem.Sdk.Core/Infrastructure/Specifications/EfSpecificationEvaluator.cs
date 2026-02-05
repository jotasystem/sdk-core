using JotaSystem.Sdk.Core.Application.Specifications;
using Microsoft.EntityFrameworkCore;

namespace JotaSystem.Sdk.Core.Infrastructure.Specifications
{
    public static class EfSpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> spec)
            where TEntity : class
        {
            var query = SpecificationEvaluator.GetQuery(inputQuery, spec);

            // 🔹 Include simples
            foreach (var include in spec.Includes)
                query = query.Include(include);

            // 🔹 Include com ThenInclude
            foreach (var include in spec.IncludeExpressions)
                query = include(query);

            return query;
        }
    }
}