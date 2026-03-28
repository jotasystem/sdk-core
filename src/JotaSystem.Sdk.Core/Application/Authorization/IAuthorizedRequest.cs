namespace JotaSystem.Sdk.Core.Application.Authorization
{
    public interface IAuthorizedRequest
    {
        AuthorizationDefinition Authorization { get; }
    }
}