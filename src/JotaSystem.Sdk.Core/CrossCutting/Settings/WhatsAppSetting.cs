using JotaSystem.Sdk.Core.CrossCutting.Providers.Enum;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    /// <summary>
    /// Servidor de WhatsApp da plataforma. Os tenants usam este servidor, a menos que a integração
    /// informe um servidor próprio.
    /// </summary>
    public class WhatsAppSetting
    {
        /// <summary>Provedor usado nas novas conexões.</summary>
        public WhatsAppProviderEnum Provider { get; set; } = WhatsAppProviderEnum.Evolution;

        /// <summary>Endereço público da API da aplicação, usado para montar a URL do webhook entregue ao provedor.</summary>
        public string? WebhookBaseUrl { get; set; }

        /// <summary>Prefixo dos nomes de instância criados por esta instalação, para separar ambientes no mesmo servidor.</summary>
        public string InstancePrefix { get; set; } = "jotasystem";

        // Configurações específicas de cada provider
        public EvolutionSetting Evolution { get; set; } = new();

        // 🔹 Subclasses para cada provider

        public class EvolutionSetting
        {
            /// <summary>Endereço do servidor da Evolution API, ex.: <c>https://evolution.minhaempresa.com.br</c>.</summary>
            public string? BaseUrl { get; set; }

            /// <summary>Chave global do servidor (<c>AUTHENTICATION_API_KEY</c>).</summary>
            public string? ApiKey { get; set; }

            public int TimeoutSeconds { get; set; } = 30;

            public bool IsConfigured =>
                Uri.TryCreate(BaseUrl, UriKind.Absolute, out _) && !string.IsNullOrWhiteSpace(ApiKey);
        }
    }
}
