namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IAiProvider
    {
        Task<string> SendAsync(string content, CancellationToken cancellationToken = default);
    }
}