using JotaSystem.Sdk.Common.Enums;

namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    public class CurrentUser
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserProfileEnum Profile { get; set; }
        public long? TenantId { get; set; }
        public long? CompanyId { get; set; }
        public List<string> Roles { get; set; } = [];
        public List<string> Permissions { get; set; } = [];
    }
}