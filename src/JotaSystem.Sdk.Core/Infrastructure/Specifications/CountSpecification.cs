using JotaSystem.Sdk.Core.Application.Specifications;

namespace JotaSystem.Sdk.Core.Infrastructure.Specifications
{
    public sealed class CountSpecification<TEntity> : Specification<TEntity>
    {
        public CountSpecification(Specification<TEntity> source)
        {
            Criteria = source.Criteria;
        }
    }
}