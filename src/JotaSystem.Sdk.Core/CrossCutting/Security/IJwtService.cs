using System.Security.Claims;

namespace JotaSystem.Sdk.Core.CrossCutting.Security
{
    public interface IJwtService
    {
        (string Token, int ExpiresIn, DateTime ExpiresAt) GenerateToken(IEnumerable<Claim> claims, int? expirationMinutes = null);
        (string Token, int ExpiresIn, DateTime ExpiresAt) GenerateRefreshToken(Guid uuId);
        ClaimsPrincipal? ValidateToken(string token);
    }
}