using JotaSystem.Sdk.Core.Domain.Abstractions;
using MediatR;

namespace JotaSystem.Sdk.Core.Domain.Events
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
