using System.Linq.Expressions;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public static class DynamicFilter
    {
        public static Expression<Func<TEntity, bool>>? Build<TEntity>(FilterQuery query)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression? body = null;

            // 🔍 Search em propriedades string
            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var stringProps = typeof(TEntity)
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var prop in stringProps)
                {
                    var member = Expression.Property(parameter, prop);

                    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });

                    var searchExpr = Expression.Call(
                        member,
                        containsMethod!,
                        Expression.Constant(query.Search)
                    );

                    body = body == null ? searchExpr : Expression.OrElse(body, searchExpr);
                }
            }

            if (body == null) return null;

            return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        }
    }
}