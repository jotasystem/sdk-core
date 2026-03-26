namespace JotaSystem.Sdk.Core.Application.Authorization
{
    public interface IAuthorizedRequest
    {
        IReadOnlyCollection<string> RequiredPermissions { get; }
    }
}