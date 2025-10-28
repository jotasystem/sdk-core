using JotaSystem.Sdk.Core.Domain.Abstractions;
using JotaSystem.Sdk.Core.Domain.Events;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.Domain.Entities
{
    /// <summary>
    /// Entidade base mínima com Id, ExternalId e suporte a Domain Events
    /// </summary>
    public abstract class EntityBase : IEntity
    {
        [Key]
        public long Id { get; protected set; }
        public Guid? ExternalId { get; protected set; }


        public void SetId(long id) => Id = id;
        public void SetExternalId(Guid externalId) => ExternalId = externalId;


        #region Igualdade

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (EntityBase)obj;
            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(EntityBase? a, EntityBase? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(EntityBase? a, EntityBase? b) => !(a == b);

        #endregion
    }
}