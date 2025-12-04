using JotaSystem.Sdk.Core.CrossCutting.Providers;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class SmsSettings
    {
        [Required]
        public SmsProvider Provider { get; set; }

        // Configurações específicas por provider
        public TwilioSetting? Twilio { get; set; }
        public TotalVoiceSetting? TotalVoice { get; set; }
        public ZenviaSetting? Zenvia { get; set; }
        public TwwSetting? Tww { get; set; }
        public InfobipSetting? Infobip { get; set; }
        public PlivoSetting? Plivo { get; set; }
        public ClickSendSetting? ClickSend { get; set; }
        public SmsDevSetting? SmsDev { get; set; }
        public FacilitaMovelSetting? FacilitaMovel { get; set; }
        public NvoipSetting? Nvoip { get; set; }
        public MessageBirdSetting? MessageBird { get; set; }

        // 🔹 Subclasses para cada provider

        public class TwilioSetting
        {
            [Required] public string AccountSid { get; set; } = string.Empty;
            [Required] public string AuthToken { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class TotalVoiceSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class ZenviaSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class TwwSetting
        {
            [Required] public string UserKey { get; set; } = string.Empty;
            [Required] public string Password { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class InfobipSetting
        {
            [Required] public string BaseUrl { get; set; } = string.Empty;
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class PlivoSetting
        {
            [Required] public string AuthId { get; set; } = string.Empty;
            [Required] public string AuthToken { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class ClickSendSetting
        {
            [Required] public string Username { get; set; } = string.Empty;
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class SmsDevSetting
        {
            [Required] public string Token { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class FacilitaMovelSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class NvoipSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }

        public class MessageBirdSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
        }
    }
}
