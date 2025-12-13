using System.Linq.Expressions;
using System.Reflection;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public static class DynamicSorter
    {
        public static Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? Build<TEntity>(FilterQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.OrderBy))
                return null;

            // Obter a propriedade na entidade TEntity
            PropertyInfo property = typeof(TEntity).GetProperty(query.OrderBy)!;
            if (property == null)
                return null;

            // Criar a expressão x => x.Prop
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
            MemberExpression propertyAccess = Expression.Property(parameter, property);
            LambdaExpression keySelector = Expression.Lambda(propertyAccess, parameter);

            // Determinar método OrderBy ou OrderByDescending
            string methodName = query.Descending ? "OrderByDescending" : "OrderBy";

            // Obter método genérico correto do Queryable
            MethodInfo method = typeof(Queryable)
                .GetMethods()
                .Where(m => m.Name == methodName && m.GetParameters().Length == 2)
                .Single()
                .MakeGenericMethod(typeof(TEntity), property.PropertyType);

            // Retornar função que aplica a ordenação
            return q => (IOrderedQueryable<TEntity>)method.Invoke(null, new object[] { q, keySelector })!;
        }
    }
}