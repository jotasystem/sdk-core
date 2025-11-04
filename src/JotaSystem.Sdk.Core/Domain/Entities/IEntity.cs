namespace JotaSystem.Sdk.Core.Domain.Entities
{
    /// <summary>
    /// Contrato que representa uma entidade com identificador numérico (long).
    /// Utilizar para tipar repositórios e abstrações.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Identificador numérico da entidade.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Identificador externo (opcional) — útil para integrações, idempotência, sincronização entre sistemas.
        /// </summary>
        Guid? ExternalId { get; }
    }
}