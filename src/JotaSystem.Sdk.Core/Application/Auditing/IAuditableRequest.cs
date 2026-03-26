namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public interface IAuditableRequest
    {
        AuditDefinition Audit();
    }
}