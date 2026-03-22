using JotaSystem.Sdk.Common.Enums;
using JotaSystem.Sdk.Core.CrossCutting.Models;

namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface ICurrentContext
    {
        bool IsAuthenticated { get; }
        CurrentUser GetUser();

        long GetTenantId();
        CompanyTypeEnum GetCurrentCompanyType();
        long GetCurrentCompanyId();
        string GetCulture();
        string GetTimeZone();
        string GetCurrency();
        string GetColor();
        string GetLogo();

        bool IsInRole(string role);
        bool IsPermissionScopeAllowed(AccessScopeEnum scope);
        bool HasPermission(string permission, AccessScopeEnum scope);
        bool HasCompanyAccess(long companyId);
    }
}