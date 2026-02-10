using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class JwtSetting
    {
        [Required] public string Issuer { get; set; } = string.Empty;
        [Required] public string Audience { get; set; } = string.Empty;
        [Required] public string SecretKey { get; set; } = string.Empty;
        [Range(1, 1440)] public int ExpirationMinutes { get; set; } = 60;
        [Range(1, 1440)] public int RefreshTokenExpirationDays { get; set; } = 7;
    }
}