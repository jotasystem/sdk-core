namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public interface IAuditAccessor
    {
        long? GetUserId();
        string? GetUsername();
        long? GetCompanyId();
        long? GetTenantId();
        string? GetCorrelationId();
        string? GetIpAddress();
        string? GetUserAgent();
        string? GetSource();
    }
}