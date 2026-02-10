using JotaSystem.Sdk.Core.CrossCutting.Providers;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class EmailSetting
    {
        [Required]
        public EmailProviderType Provider { get; set; } = EmailProviderType.Smtp;

        // Configurações específicas de cada provider
        public SmtpSetting? Smtp { get; set; }
        public SendGridSetting? SendGrid { get; set; }
        public BrevoSetting? Brevo { get; set; }
        public SendPulseSetting? SendPulse { get; set; }
        public AmazonSesSetting? AmazonSes { get; set; }
        public MailgunSetting? Mailgun { get; set; }
        public MailjetSetting? Mailjet { get; set; }
        public GoogleWorkspaceSetting? GoogleWorkspace { get; set; }
        public Microsoft365Setting? Microsoft365 { get; set; }
        public LocawebSetting? Locaweb { get; set; }
        public KingHostSetting? KingHost { get; set; }
        public UolHostSetting? UolHost { get; set; }

        // 🔹 Subclasses para cada provider
        public class SmtpSetting
        {
            [Required] public string Host { get; set; } = string.Empty;
            [Required] public int Port { get; set; } = 587;
            [Required] public string Username { get; set; } = string.Empty;
            [Required] public string Password { get; set; } = string.Empty;
            [Required] public string From { get; set; } = string.Empty;
            public bool EnableSsl { get; set; } = true;
        }

        public class SendGridSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class BrevoSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class SendPulseSetting
        {
            [Required] public string Id { get; set; } = string.Empty;
            [Required] public string Secret { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class AmazonSesSetting
        {
            [Required] public string AccessKey { get; set; } = string.Empty;
            [Required] public string SecretKey { get; set; } = string.Empty;
            [Required] public string Region { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class MailgunSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string Domain { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class MailjetSetting
        {
            [Required] public string PublicKey { get; set; } = string.Empty;
            [Required] public string PrivateKey { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class GoogleWorkspaceSetting
        {
            [Required] public string Username { get; set; } = string.Empty;
            [Required] public string Password { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class Microsoft365Setting
        {
            [Required] public string TenantId { get; set; } = string.Empty;
            [Required] public string ClientId { get; set; } = string.Empty;
            [Required] public string ClientSecret { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
        }

        public class LocawebSetting
        {
            [Required] public string Host { get; set; } = string.Empty;
            [Required] public int Port { get; set; } = 587;
            [Required] public string Username { get; set; } = string.Empty;
            [Required] public string Password { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
            public bool EnableSsl { get; set; } = true;
        }

        public class KingHostSetting
        {
            [Required] public string Host { get; set; } = string.Empty;
            [Required] public int Port { get; set; } = 587;
            [Required] public string Username { get; set; } = string.Empty;
            [Required] public string Password { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
            public bool EnableSsl { get; set; } = true;
        }

        public class UolHostSetting
        {
            [Required] public string Host { get; set; } = string.Empty;
            [Required] public int Port { get; set; } = 587;
            [Required] public string Username { get; set; } = string.Empty;
            [Required] public string Password { get; set; } = string.Empty;
            [Required] public string FromEmail { get; set; } = string.Empty;
            public string? FromName { get; set; }
            public bool EnableSsl { get; set; } = true;
        }
    }
}