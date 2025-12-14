namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface ITenantContext
    {
        Task<long> GetTenantId();
    }
}