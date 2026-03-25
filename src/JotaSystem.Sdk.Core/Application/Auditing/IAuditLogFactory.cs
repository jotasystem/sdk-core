namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public interface IAuditLogFactory<TLog>
    {
        TLog Create(AuditContext context, bool isSuccess);
    }
}