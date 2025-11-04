namespace JotaSystem.Sdk.Core.Domain.Entities
{
    /// <summary>
    /// Contrato para entidades que pertencem a um tenant (multi-tenant simples por id).
    /// </summary>
    public interface ITenantEntity
    {
        /// <summary>
        /// Identificador do tenant proprietário da entidade.
        /// </summary>
        long TenantId { get; }
    }
}