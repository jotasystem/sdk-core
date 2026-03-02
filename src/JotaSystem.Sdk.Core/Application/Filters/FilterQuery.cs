namespace JotaSystem.Sdk.Core.Application.Filters
{
    public record FilterQuery : PagedQuery
    {
        public string? Search { get; init; }
        public Dictionary<string, string>? Filters { get; init; }

        public string? OrderBy { get; init; }
        public bool OrderByDescending { get; init; }
    }
}