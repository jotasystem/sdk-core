namespace JotaSystem.Sdk.Core.Domain.Enums
{
    /// <summary>
    /// Representa o estado atual de uma entidade do sistema.
    /// </summary>
    public enum EntityStatusEnum
    {
        /// <summary>
        /// Entidade criada mas ainda não publicada ou aprovada.
        /// </summary>
        Draft = 0,

        /// <summary>
        /// Entidade ativa e disponível para uso no sistema.
        /// </summary>
        Active = 1,

        /// <summary>
        /// Entidade inativa, não disponível para operações normais.
        /// </summary>
        Inactive = 2,

        /// <summary>
        /// Entidade arquivada, mantida apenas para histórico.
        /// </summary>
        Archived = 3,

        /// <summary>
        /// Entidade aguardando aprovação antes de se tornar ativa.
        /// </summary>
        PendingApproval = 4
    }
}