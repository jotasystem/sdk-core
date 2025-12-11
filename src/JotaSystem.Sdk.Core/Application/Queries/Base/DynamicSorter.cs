using JotaSystem.Sdk.Core.Domain.Entities;
using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public static class DynamicSorter
    {
        public static Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? Build<TEntity>(FilterQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.SortBy))
                return null;

            var property = typeof(TEntity).GetProperty(query.SortBy);
            if (property == null)
                return null;

            var param = Expression.Parameter(typeof(TEntity), "x");
            var body = Expression.Property(param, property);

            var keySelector = Expression.Lambda(body, param);

            var methodName = query.Descending ? "OrderByDescending" : "OrderBy";

            return q =>
            {
                var method = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == methodName
                                && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(IEntity), property.PropertyType);

                return (IOrderedQueryable<TEntity>)method.Invoke(null, [q, keySelector])!;
            };
        }
    }
}