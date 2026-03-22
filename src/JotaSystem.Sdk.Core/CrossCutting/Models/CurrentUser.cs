using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    public class CurrentUser
    {
        public UserTypeEnum UserType { get; init; }
        public long UserId { get; init; }
        public Guid UserUuid { get; init; }
        public string Username { get; init; } = default!;
        public string Nickname { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string PhoneNumber { get; init; } = default!;
        public string Picture { get; init; } = default!;

        public bool HasFullAccess { get; init; }

        public long TenantId { get; init; }
        public CompanyTypeEnum CurrentCompanyType { get; init; }
        public long CurrentCompanyId { get; init; }
        public IReadOnlyCollection<long> AllowedCompaniesIds { get; init; } = [];

        public string Culture { get; init; } = default!;
        public string TimeZone { get; init; } = default!;
        public string Currency { get; init; } = default!;
        public string Color { get; init; } = default!;
        public string Logo { get; init; } = default!;

        public IReadOnlyCollection<string> Roles { get; init; } = [];
        public IReadOnlyCollection<string> Permissions { get; init; } = [];
    }
}