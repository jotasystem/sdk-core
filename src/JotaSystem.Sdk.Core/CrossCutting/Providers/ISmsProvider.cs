namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface ISmsProvider
    {
        Task<bool> SendAsync(string recipient, string message);
    }
}
