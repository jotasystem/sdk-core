using JotaSystem.Sdk.Common.Constants;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public record FilterQuery(
        string? Search = null,
        Dictionary<string, string>? Filters = null,
        string? SortBy = null,
        bool Descending = false,
        int Page = AppConstant.DefaultPage,
        int PageSize = AppConstant.DefaultPageSize) : PagedQuery(Page, PageSize);
}