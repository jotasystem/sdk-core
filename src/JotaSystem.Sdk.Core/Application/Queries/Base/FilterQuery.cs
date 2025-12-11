using JotaSystem.Sdk.Common.Constants;

namespace JotaSystem.Sdk.Core.Application.Queries.Base
{
    public record FilterQuery(
        string? Search = null,
        Dictionary<string, string>? Filters = null,
        string? SortBy = null,
        bool Descending = false,
        int Page = 1,
        int PageSize = AppConstants.DefaultPageSize) : PagedQuery(Page, PageSize);
}