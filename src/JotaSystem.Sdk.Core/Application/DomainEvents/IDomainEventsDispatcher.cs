namespace JotaSystem.Sdk.Core.Application.DomainEvents
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}