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
        bool HasPermission(string permission);
        bool HasCompanyAccess(long companyId);
    }
}