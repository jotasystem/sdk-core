using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public enum PushNotificationProvider
    {
        [Display(Name = "Firebase Cloud Messaging (FCM)")]
        [EnumMember(Value = "fcm")]
        Fcm = 0,

        [Display(Name = "OneSignal")]
        [EnumMember(Value = "onesignal")]
        OneSignal = 1,

        [Display(Name = "Pusher Beams")]
        [EnumMember(Value = "pusher")]
        Pusher = 2
    }
}