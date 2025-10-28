using JotaSystem.Sdk.Core.Domain.Abstractions;
using JotaSystem.Sdk.Core.Domain.Events;

namespace JotaSystem.Sdk.Core.Domain
{
    public abstract class AggregateRootBase : IAggregateRoot
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        public IReadOnlyCollection<IDomainEvent> Events => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent @event)
        {
            if (@event == null) return;

            _domainEvents.Add(@event);
            DomainEvents.Raise(@event); // envia para o centralizador
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}