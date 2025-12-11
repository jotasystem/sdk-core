using JotaSystem.Sdk.Common.Constants;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public abstract record PagedQuery(int Page = AppConstant.DefaultPage, int PageSize = AppConstant.DefaultPageSize);
}