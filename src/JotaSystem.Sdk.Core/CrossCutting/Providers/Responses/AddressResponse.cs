namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Responses
{
    public class AddressResponse
    {
        public string ZipCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
    }
}