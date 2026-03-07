using JotaSystem.Sdk.Core.CrossCutting.Models;
using System.Security.Claims;

namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface IUserContext
    {
        bool IsAuthenticated { get; }

        CurrentUser Get();

        bool IsInRole(string role);
        bool HasPermission(string permission);
        bool HasCompanyAccess(long companyId);
        bool HasCurrentCompany();


        // Gerar claims para o JWT
        IEnumerable<Claim> GetClaimsFor(CurrentUser user);
    }
}