using JotaSystem.Sdk.Core.CrossCutting.Providers.Enum;
using JotaSystem.Sdk.Core.CrossCutting.Providers.Models;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    /// <summary>
    /// Fachada de WhatsApp da aplicação. Encaminha cada chamada ao provedor da integração
    /// (<see cref="WhatsAppProviderContext.ProviderKey"/>), sem expor o contrato de cada SDK.
    /// </summary>
    public interface IWhatsAppProvider
    {
        bool IsSupported(string providerKey);

        /// <summary>Há servidor padrão configurado para o provedor no appsettings.</summary>
        bool HasDefaultServer(string providerKey);

        /// <summary>Confere se o servidor responde e se a chave é aceita.</summary>
        Task<WhatsAppServerStatus> GetServerStatusAsync(string providerKey, WhatsAppProviderContext? context = null,
            CancellationToken cancellationToken = default);

        Task<WhatsAppCreateInstanceResult> CreateInstanceAsync(WhatsAppProviderContext context,
            WhatsAppSessionSettings settings, string? webhookUrl, CancellationToken cancellationToken = default);

        /// <summary>Inicia ou renova o pareamento. Com o número, devolve também o código de pareamento.</summary>
        Task<WhatsAppConnectResult> ConnectAsync(WhatsAppProviderContext context, string? phoneNumber = null,
            CancellationToken cancellationToken = default);

        Task<WhatsAppInstanceStatus> GetStatusAsync(WhatsAppProviderContext context,
            CancellationToken cancellationToken = default);

        /// <summary>Reaplica as preferências da sessão e o webhook na instância.</summary>
        Task<WhatsAppOperationResult> ConfigureAsync(WhatsAppProviderContext context, WhatsAppSessionSettings settings,
            string? webhookUrl, CancellationToken cancellationToken = default);

        Task<WhatsAppOperationResult> RestartAsync(WhatsAppProviderContext context,
            CancellationToken cancellationToken = default);

        Task<WhatsAppOperationResult> LogoutAsync(WhatsAppProviderContext context,
            CancellationToken cancellationToken = default);

        Task<WhatsAppOperationResult> DeleteAsync(WhatsAppProviderContext context,
            CancellationToken cancellationToken = default);

        Task<WhatsAppSendResult> SendTextAsync(WhatsAppProviderContext context, string phoneNumber, string text,
            CancellationToken cancellationToken = default);

        Task<WhatsAppSendResult> SendMediaAsync(WhatsAppProviderContext context, string phoneNumber, WhatsAppMedia media,
            CancellationToken cancellationToken = default);

        /// <summary>Normaliza o número para o formato do provedor (apenas dígitos, com DDI). Nulo quando inválido.</summary>
        string? NormalizePhoneNumber(string providerKey, string? phoneNumber);

        /// <summary>Lê a notificação do webhook. Nulo quando o conteúdo não é reconhecido.</summary>
        WhatsAppWebhookEvent? ParseWebhook(string providerKey, string payload);
    }
}
