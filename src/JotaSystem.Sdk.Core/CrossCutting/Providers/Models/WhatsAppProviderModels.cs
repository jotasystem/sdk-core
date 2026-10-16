using JotaSystem.Sdk.Core.CrossCutting.Providers.Enum;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Models
{
    /// <summary>Chaves dos provedores de WhatsApp, iguais ao <c>EnumMember</c> de <see cref="WhatsAppProviderEnum"/>.</summary>
    public static class WhatsAppProviderKeys
    {
        public const string Evolution = "evolution";

        public static IReadOnlyList<(string Key, string Name)> All { get; } = [(Evolution, "Evolution API")];

        public static string GetName(string? providerKey) =>
            All.FirstOrDefault(x => string.Equals(x.Key, providerKey, StringComparison.OrdinalIgnoreCase)).Name
            ?? providerKey
            ?? string.Empty;
    }

    /// <summary>
    /// Dados de uma instância para a chamada ao provedor. Sem servidor próprio, vale o servidor de
    /// <see cref="Settings.WhatsAppSetting"/>.
    /// </summary>
    public sealed record WhatsAppProviderContext(
        string ProviderKey,
        string InstanceName,
        string? InstanceToken = null,
        string? ServerUrl = null,
        string? ServerApiKey = null)
    {
        public bool HasOwnServer => !string.IsNullOrWhiteSpace(ServerUrl) && !string.IsNullOrWhiteSpace(ServerApiKey);
    }

    /// <summary>Comportamento da sessão no WhatsApp.</summary>
    public sealed record WhatsAppSessionSettings(
        bool RejectCalls,
        string? RejectCallMessage,
        bool IgnoreGroups,
        bool AlwaysOnline,
        bool ReadMessages);

    public sealed record WhatsAppOperationResult(bool IsSuccess, string? Message = null)
    {
        public static WhatsAppOperationResult Ok() => new(true);
        public static WhatsAppOperationResult Fail(string? message) => new(false, message);
    }

    public sealed record WhatsAppServerStatus(bool IsSuccess, string? Version, string? Message);

    public sealed record WhatsAppQrCode(string? ImageDataUri, string? Code, string? PairingCode);

    public sealed record WhatsAppCreateInstanceResult(bool IsSuccess, string? InstanceToken, WhatsAppQrCode? QrCode,
        string? Message);

    public sealed record WhatsAppConnectResult(bool IsSuccess, WhatsAppSessionStateEnum State, WhatsAppQrCode? QrCode,
        string? Message);

    /// <summary>Situação da instância. <see cref="Exists"/> falso indica que ela não existe mais no provedor.</summary>
    public sealed record WhatsAppInstanceStatus(
        bool IsSuccess,
        bool Exists,
        WhatsAppSessionStateEnum State,
        string? PhoneNumber,
        string? ProfileName,
        string? ProfilePictureUrl,
        string? Message);

    public sealed record WhatsAppSendResult(bool IsSuccess, string? MessageId, string? Message);

    /// <summary>Arquivo enviado por URL pública ou em base64.</summary>
    public sealed record WhatsAppMedia(string Content, string MimeType, string? FileName = null, string? Caption = null);

    /// <summary>Notificação do provedor já normalizada.</summary>
    public sealed record WhatsAppWebhookEvent(
        WhatsAppWebhookEventTypeEnum Type,
        string RawEvent,
        string? InstanceName,
        string? InstanceToken,
        WhatsAppSessionStateEnum? State,
        int? StatusReason,
        string? PhoneNumber,
        string? ProfileName,
        string? ProfilePictureUrl,
        string? MessageId,
        string? MessageStatus,
        string? RemotePhoneNumber,
        string? Text);
}
