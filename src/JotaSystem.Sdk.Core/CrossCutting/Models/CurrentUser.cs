using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    public class CurrentUser
    {
        public Guid UserId { get; set; }
        public long TenantId { get; set; }
        public long? CompanyId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public UserProfileEnum Profile { get; set; }
        public List<string> Roles { get; set; } = [];
        public List<string> Permissions { get; set; } = [];
        public string Culture { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
    }
}