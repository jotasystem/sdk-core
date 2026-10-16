using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    /// <summary>
    /// Provedores de WhatsApp. O <see cref="EnumMemberAttribute.Value"/> é a chave gravada na integração
    /// (<c>WhatsAppProviderContext.ProviderKey</c>).
    /// </summary>
    public enum WhatsAppProviderEnum
    {
        [Display(Name = "Evolution API")]
        [EnumMember(Value = "evolution")]
        Evolution = 0
    }

    /// <summary>Estado da sessão do número no provedor de WhatsApp.</summary>
    public enum WhatsAppSessionStateEnum
    {
        Unknown = 0,
        Disconnected = 1,
        Connecting = 2,
        Connected = 3
    }

    /// <summary>Tipo da notificação recebida do provedor de WhatsApp, já normalizado.</summary>
    public enum WhatsAppWebhookEventTypeEnum
    {
        Other = 0,
        ConnectionUpdate = 1,
        QrCodeUpdated = 2,
        MessageReceived = 3,
        MessageStatus = 4,
        MessageSent = 5,
        InstanceRemoved = 6
    }
}
