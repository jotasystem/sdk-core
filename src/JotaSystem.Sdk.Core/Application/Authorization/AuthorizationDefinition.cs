using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Core.Application.Authorization
{
    public sealed class AuthorizationDefinition
    {
        public AuthorizationMode Mode { get; init; }
        public IReadOnlyCollection<string> RequiredPermissions { get; init; } = [];


        public static AuthorizationDefinition None()
            => new() { Mode = AuthorizationMode.None };

        public static AuthorizationDefinition AdminOnly()
            => new() { Mode = AuthorizationMode.AdminOnly };

        public static AuthorizationDefinition Permission(params string[] permissions)
            => new()
            {
                Mode = AuthorizationMode.Permission,
                RequiredPermissions = permissions
            };
    }
}