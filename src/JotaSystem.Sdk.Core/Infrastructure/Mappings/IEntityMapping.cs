namespace JotaSystem.Sdk.Core.Infrastructure.Mappings
{
    public interface IEntityMapping<T>
        where T : class
    {
        void Configure(object builder);
    }
}