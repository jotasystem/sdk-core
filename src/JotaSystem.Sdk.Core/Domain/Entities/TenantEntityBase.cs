using JotaSystem.Sdk.Core.Domain.Abstractions;
using JotaSystem.Sdk.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.Domain.Entities
{
    public abstract class TenantEntityBase : EntityBase, ITenantEntity, IAuditable, ISoftDelete
    {
        public long TenantId { get; protected set; }
        public EntityStatusEnum Status { get; protected set; } = EntityStatusEnum.Active;
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }

        /// <summary>
        /// Coluna de controle de concorrência (RowVersion / Timestamp).
        /// O valor é gerenciado automaticamente pelo ORM/banco.
        /// Útil para detectar atualizações simultâneas e evitar sobrescrita de dados.
        /// </summary>
        [Timestamp]
        public byte[]? RowVersion { get; protected set; }


        public void SetTenant(long tenantId) => TenantId = tenantId;

        public void SetStatus(EntityStatusEnum status) => Status = status;

        #region Auditable / SoftDelete

        public void Update(DateTime? updatedAt = null) => UpdatedAt = updatedAt ?? DateTime.UtcNow;

        public void Delete()
        {
            if (IsDeleted) return;
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            SetStatus(EntityStatusEnum.Inactive);
        }

        public void Restore()
        {
            if (!IsDeleted) return;
            IsDeleted = false;
            DeletedAt = null;
            SetStatus(EntityStatusEnum.Active);
        }

        #endregion
    }
}