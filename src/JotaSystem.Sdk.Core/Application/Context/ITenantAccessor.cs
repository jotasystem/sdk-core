namespace JotaSystem.Sdk.Core.Application.Context
{
    public interface ITenantAccessor
    {
        long TenantId { get; set; }
    }
}