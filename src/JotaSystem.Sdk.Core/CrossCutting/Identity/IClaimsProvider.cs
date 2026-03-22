using JotaSystem.Sdk.Core.CrossCutting.Models;
using System.Security.Claims;

namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface IClaimsProvider
    {
        IEnumerable<Claim> GetClaimsFor(CurrentUser user);
    }
}