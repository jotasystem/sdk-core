namespace JotaSystem.Sdk.Core.Domain.Events
{
    /// <summary>
    /// Marca um evento como de domínio.
    /// Eventos de domínio representam alterações importantes de negócio.
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// Data/hora em que o evento ocorreu.
        /// </summary>
        DateTime OccurredOn { get; }
    }
}