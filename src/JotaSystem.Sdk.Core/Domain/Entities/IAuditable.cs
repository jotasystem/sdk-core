namespace JotaSystem.Sdk.Core.Domain.Entities
{
    /// <summary>
    /// Contrato para entidades que possuem auditoria básica (criado / atualizado).
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Data de criação em UTC.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Data de última atualização em UTC (pode ser nulo).
        /// </summary>
        DateTime? UpdatedAt { get; }

        /// <summary>
        /// Marca a entidade como atualizada.
        /// </summary>
        void Update(DateTime? updatedAt = null);
    }
}