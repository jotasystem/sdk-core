namespace JotaSystem.Sdk.Core.Application.Abstractions
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}