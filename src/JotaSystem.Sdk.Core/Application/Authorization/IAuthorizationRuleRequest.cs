using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Core.Application.Authorization
{
    public interface IAuthorizationRuleRequest : IAuthorizedRequest
    {
        AccessScopeEnum RequiredPermissionScope => AccessScopeEnum.Any;
        bool RequiresAuthenticatedUser => false;
        bool AllowAdminBypass => true;
    }
}