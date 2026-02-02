namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface ITenantContext
    {
        long GetTenantId();
    }
}