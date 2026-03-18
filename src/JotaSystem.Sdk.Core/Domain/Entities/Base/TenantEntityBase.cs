namespace JotaSystem.Sdk.Core.Domain.Entities.Base
{
    public abstract class TenantEntityBase : EntityBase, ITenantEntity, IAuditable, ISoftDelete
    {
        public long TenantId { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }

        public virtual void SetTenant(long tenantId) => TenantId = tenantId;

        public void Update(DateTime? updatedAt = null) => UpdatedAt = updatedAt ?? DateTime.UtcNow;

        public void Delete()
        {
            if (IsDeleted) return;
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            if (!IsDeleted) return;
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}