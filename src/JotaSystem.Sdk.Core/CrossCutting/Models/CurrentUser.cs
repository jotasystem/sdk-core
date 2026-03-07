using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    public class CurrentUser
    {
        public long UserId { get; set; }
        public UserTypeEnum UserType { get; set; }

        public long TenantId { get; set; }
        public string TenantImage { get; set; } = default!;
        public string TenantColor { get; set; } = default!;

        public long? CurrentCompanyId { get; set; }
        public long? DefaultCompanyId { get; set; }
        public IReadOnlyCollection<long> AllowedCompanyIds { get; set; } = [];

        public string Username { get; set; } = default!;
        public string Nickname { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Picture { get; set; } = default!;
        public bool HasFullAccess { get; set; }

        public string Culture { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;

        public IReadOnlyCollection<string> Roles { get; set; } = [];
        public IReadOnlyCollection<string> Permissions { get; set; } = [];

    }
}