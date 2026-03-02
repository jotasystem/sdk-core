using JotaSystem.Sdk.Common.Constants;

namespace JotaSystem.Sdk.Core.Application.Filters
{
    public abstract record PagedQuery
    {
        public int Page { get; init; } = AppConstant.DefaultPage;
        public int PageSize { get; init; } = AppConstant.DefaultPageSize;
    }
}