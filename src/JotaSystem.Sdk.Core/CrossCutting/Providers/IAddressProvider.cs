using JotaSystem.Sdk.Core.CrossCutting.Providers.Responses;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IAddressProvider
    {
        Task<AddressResponse?> GetAddressAsync(string zipCode);
    }
}