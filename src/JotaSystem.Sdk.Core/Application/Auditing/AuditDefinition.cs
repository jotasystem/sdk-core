namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public sealed class AuditDefinition
    {
        public string Category { get; init; } = default!;
        public string EventType { get; init; } = default!;
        public string EntityName { get; init; } = default!;
        public string? Source { get; init; }
        public bool LogOnSuccess { get; init; } = true;
        public bool LogOnFailure { get; init; } = true;
    }
}