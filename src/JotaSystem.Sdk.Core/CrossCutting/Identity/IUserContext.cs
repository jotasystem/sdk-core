using JotaSystem.Sdk.Core.CrossCutting.Models;
using System.Security.Claims;

namespace JotaSystem.Sdk.Core.CrossCutting.Identity
{
    public interface IUserContext
    {
        // Gerar claims para o JWT
        IEnumerable<Claim> GetClaimsFor(CurrentUser user);


        // Acessar claims do usuário autenticado
        bool IsAuthenticated { get; }
        CurrentUser Get();
        bool IsInRole(string role);
        bool HasPermission(string permission);
    }
}