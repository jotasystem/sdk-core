namespace JotaSystem.Sdk.Core.Domain.Entities
{
    /// <summary>
    /// Contrato para entidades com exclusão lógica (soft delete).
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Indica se a entidade foi marcada como excluída.
        /// </summary>
        bool IsDeleted { get; }

        /// <summary>
        /// Data em que a entidade foi marcada como excluída (UTC).
        /// </summary>
        DateTime? DeletedAt { get; }

        /// <summary>
        /// Marca a entidade como excluída logicamente, ajustando flags e DeletedAt
        /// </summary>
        void Delete();

        /// <summary>
        /// Restaura uma entidade que foi excluída logicamente.
        /// </summary>
        void Restore();
    }
}
