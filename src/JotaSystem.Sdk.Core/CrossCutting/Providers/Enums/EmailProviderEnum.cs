using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    public enum EmailProviderEnum
    {
        [Display(Name = "SMTP Padrão")]
        [EnumMember(Value = "smtp")]
        Smtp = 0,

        [Display(Name = "Brevo")]
        [EnumMember(Value = "brevo")]
        Brevo = 1,

        [Display(Name = "SendGrid")]
        [EnumMember(Value = "sendgrid")]
        SendGrid = 2,

        [Display(Name = "SendPulse")]
        [EnumMember(Value = "sendpulse")]
        SendPulse = 3,

        [Display(Name = "Amazon SES")]
        [EnumMember(Value = "amazon_ses")]
        AmazonSes = 4,

        [Display(Name = "Mailgun")]
        [EnumMember(Value = "mailgun")]
        Mailgun = 5,

        [Display(Name = "Mailjet")]
        [EnumMember(Value = "mailjet")]
        Mailjet = 6,

        [Display(Name = "Gmail / Google Workspace")]
        [EnumMember(Value = "google_workspace")]
        GoogleWorkspace = 7,

        [Display(Name = "Microsoft 365 / Exchange Online")]
        [EnumMember(Value = "microsoft_365")]
        Microsoft365 = 8,

        [Display(Name = "Locaweb SMTP")]
        [EnumMember(Value = "locaweb")]
        Locaweb = 9,

        [Display(Name = "KingHost SMTP")]
        [EnumMember(Value = "kinghost")]
        KingHost = 10,

        [Display(Name = "UOL Host SMTP")]
        [EnumMember(Value = "uol_host")]
        UolHost = 11
    }
}