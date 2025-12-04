using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public enum PaymentProviderType
    {
        [Display(Name = "Mercado Pago")]
        [EnumMember(Value = "mercado_pago")]
        MercadoPago = 0,

        [Display(Name = "Pagar.me")]
        [EnumMember(Value = "pagarme")]
        Pagarme = 1,

        [Display(Name = "Iugu")]
        [EnumMember(Value = "iugu")]
        Iugu = 2,

        [Display(Name = "Vindi")]
        [EnumMember(Value = "vindi")]
        Vindi = 3,

        [Display(Name = "Asaas")]
        [EnumMember(Value = "asaas")]
        Asaas = 4,

        [Display(Name = "Pense Pago")]
        [EnumMember(Value = "pense_pago")]
        PensePago = 5,

        [Display(Name = "Juno (C6 Bank)")]
        [EnumMember(Value = "juno")]
        Juno = 6,

        [Display(Name = "Cielo")]
        [EnumMember(Value = "cielo")]
        Cielo = 7,

        [Display(Name = "Stone")]
        [EnumMember(Value = "stone")]
        Stone = 8,

        [Display(Name = "Rede")]
        [EnumMember(Value = "rede")]
        Rede = 9,

        [Display(Name = "GerenciaNet")]
        [EnumMember(Value = "gerencianet")]
        GerenciaNet = 10,

        [Display(Name = "PayPal")]
        [EnumMember(Value = "paypal")]
        PayPal = 11,

        [Display(Name = "Stripe")]
        [EnumMember(Value = "stripe")]
        Stripe = 12
    }
}