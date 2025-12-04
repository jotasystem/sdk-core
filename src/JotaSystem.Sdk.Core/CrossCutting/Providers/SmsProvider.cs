using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public enum SmsProvider
    {
        // Principais no Brasil
        [Display(Name = "Twilio")]
        [EnumMember(Value = "twilio")]
        Twilio = 0,

        [Display(Name = "TotalVoice / Zenvia")]
        [EnumMember(Value = "totalvoice")]
        TotalVoice = 1,

        [Display(Name = "Zenvia SMS")]
        [EnumMember(Value = "zenvia")]
        Zenvia = 2,

        [Display(Name = "TWW SMS")]
        [EnumMember(Value = "tww")]
        Tww = 3,

        [Display(Name = "Infobip")]
        [EnumMember(Value = "infobip")]
        Infobip = 4,

        [Display(Name = "Plivo")]
        [EnumMember(Value = "plivo")]
        Plivo = 5,

        [Display(Name = "ClickSend")]
        [EnumMember(Value = "clicksend")]
        ClickSend = 6,

        [Display(Name = "SMS Dev")]
        [EnumMember(Value = "smsdev")]
        SmsDev = 7,

        [Display(Name = "Facilitamóvel")]
        [EnumMember(Value = "facilitamovel")]
        FacilitaMovel = 8,

        [Display(Name = "Nvoip")]
        [EnumMember(Value = "nvoip")]
        Nvoip = 9,

        [Display(Name = "MessageBird")]
        [EnumMember(Value = "messagebird")]
        MessageBird = 10,
    }
}