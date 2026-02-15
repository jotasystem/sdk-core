using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    public enum AddressProviderEnum
    {
        [Display(Name = "ViaCEP")]
        [EnumMember(Value = "viacep")]
        ViaCep = 0,

        [Display(Name = "BrasilAPI")]
        [EnumMember(Value = "brasilapi")]
        BrasilApi = 1,

        [Display(Name = "Correios")]
        [EnumMember(Value = "correios")]
        Correios = 2
    }
}