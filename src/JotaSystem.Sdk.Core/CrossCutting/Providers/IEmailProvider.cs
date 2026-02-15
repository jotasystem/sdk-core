namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IEmailProvider
    {
        Task<bool> SendAsync(List<(string Email, string Name)> tos, string subject, string body, bool isHtml = true);
    }
}