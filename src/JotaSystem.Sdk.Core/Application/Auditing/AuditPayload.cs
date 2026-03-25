namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public sealed class AuditPayload
    {
        public long? EntityId { get; init; }
        public string? Description { get; init; }
        public object? OldValues { get; init; }
        public object? NewValues { get; init; }
        public object? Metadata { get; init; }
    }
}