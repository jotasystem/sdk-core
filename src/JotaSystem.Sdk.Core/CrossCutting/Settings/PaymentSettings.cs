using JotaSystem.Sdk.Core.CrossCutting.Providers;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class PaymentSettings
    {
        [Required] 
        public PaymentProvider Provider { get; set; }

        // Configurações específicas de cada provider
        public MercadoPagoSetting? MercadoPago { get; set; }
        public PagarmeSetting? Pagarme { get; set; }
        public IuguSetting? Iugu { get; set; }
        public VindiSetting? Vindi { get; set; }
        public AsaasSetting? Asaas { get; set; }
        public PensePagoSetting? PensePago { get; set; }
        public JunoSetting? Juno { get; set; }
        public CieloSetting? Cielo { get; set; }
        public StoneSetting? Stone { get; set; }
        public RedeSetting? Rede { get; set; }
        public GerenciaNetSetting? GerenciaNet { get; set; }
        public PayPalSetting? PayPal { get; set; }
        public StripeSetting? Stripe { get; set; }

        // 🔹 Subclasses para cada provider

        public class MercadoPagoSetting
        {
            [Required] public string AccessToken { get; set; } = string.Empty;
            [Required] public string PublicKey { get; set; } = string.Empty;
        }

        public class PagarmeSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
        }

        public class IuguSetting
        {
            [Required] public string ApiToken { get; set; } = string.Empty;
        }

        public class VindiSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
        }

        public class AsaasSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
        }

        public class PensePagoSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
        }

        public class JunoSetting
        {
            [Required] public string ClientId { get; set; } = string.Empty;
            [Required] public string ClientSecret { get; set; } = string.Empty;
        }

        public class CieloSetting
        {
            [Required] public string MerchantId { get; set; } = string.Empty;
            [Required] public string MerchantKey { get; set; } = string.Empty;
            public bool Sandbox { get; set; } = true;
        }

        public class StoneSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string Token { get; set; } = string.Empty;
        }

        public class RedeSetting
        {
            [Required] public string MerchantId { get; set; } = string.Empty;
            [Required] public string ApiKey { get; set; } = string.Empty;
        }

        public class GerenciaNetSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string ApiToken { get; set; } = string.Empty;
        }

        public class PayPalSetting
        {
            [Required] public string ClientId { get; set; } = string.Empty;
            [Required] public string ClientSecret { get; set; } = string.Empty;
            public bool Sandbox { get; set; } = true;
        }

        public class StripeSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            public string? WebhookSecret { get; set; }
        }
    }
}