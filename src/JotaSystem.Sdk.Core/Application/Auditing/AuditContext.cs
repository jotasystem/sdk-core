namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public sealed class AuditContext
    {
        public string Category { get; set; } = default!;
        public string EventType { get; set; } = default!;
        public string EntityName { get; set; } = default!;
        public string? Description { get; set; }

        public bool LogOnSuccess { get; set; }
        public bool LogOnFailure { get; set; }

        public long? EntityId { get; set; }

        public long? ActorUserId { get; set; }
        public string? ActorUsername { get; set; }
        public long? CompanyId { get; set; }
        public long? TenantId { get; set; }

        public string? Source { get; set; }
        public string? CorrelationId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? ErrorMessage { get; set; }

        public object? OldValues { get; set; }
        public object? NewValues { get; set; }
        public object? Metadata { get; set; }
    }
}