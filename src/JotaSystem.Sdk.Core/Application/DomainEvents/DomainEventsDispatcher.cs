using MediatR;

namespace JotaSystem.Sdk.Core.Application.DomainEvents
{
    public class DomainEventsDispatcher(IMediator mediator) : IDomainEventsDispatcher
        
    {
        private readonly IMediator _mediator = mediator;

        public Task DispatchAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task DispatchEventsAsync()
        {
            var events = Domain.Events.DomainEvents.GetEvents();

            foreach (var domainEvent in events)
            {
                // Publica cada evento para todos os handlers registrados
                await _mediator.Publish(domainEvent);
            }

            Domain.Events.DomainEvents.Clear();
        }
    }
}