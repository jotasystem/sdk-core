namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface ITenantProvider
    {
        long GetTenantId();
    }
}