namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public sealed class AuditDefinition
    {
        public string EntityName { get; init; } = default!;
        public string Action { get; init; } = default!;
        public string? Description { get; set; }
        public string? Source { get; init; }
        public bool LogOnSuccess { get; init; } = true;
        public bool LogOnFailure { get; init; } = true;
    }
}