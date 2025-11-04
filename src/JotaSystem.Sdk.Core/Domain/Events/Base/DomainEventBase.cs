using MediatR;

namespace JotaSystem.Sdk.Core.Domain.Events.Base
{
    public abstract class DomainEventBase : IDomainEvent, INotification
    {
        protected DomainEventBase()
        {
            OccurredOn = DateTime.UtcNow;
        }

        public DateTime OccurredOn { get; }
    }
}
