namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public interface IAuditScope
    {
        AuditContext Current { get; }

        void Start(AuditDefinition definition, AuditPayload? payload = null);
        void SetPayload(AuditPayload? payload);
        void SetDescription(string? description);
        void SetEntity(long? entityId);
        void SetOldValues(object? oldValues);
        void SetNewValues(object? newValues);
        void SetMetadata(object? metadata);
        void SetError(string? errorMessage);
        void SetActor(long? actorUserId, string? actorUsername, long? companyId, long? tenantId);
        void SetEnvironment(string? correlationId, string? ipAddress, string? userAgent, string? source = null);
        void Reset();
    }
}