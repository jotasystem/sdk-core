using JotaSystem.Sdk.Common.Constants;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public abstract record PagedQuery(int Page = 1, int PageSize = AppConstants.DefaultPageSize);
}