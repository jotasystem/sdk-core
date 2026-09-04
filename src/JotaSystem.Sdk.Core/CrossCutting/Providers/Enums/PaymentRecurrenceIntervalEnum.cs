using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    /// <summary>
    /// Periodicidade de uma cobranca recorrente. O valor numerico e o intervalo em meses.
    /// </summary>
    public enum PaymentRecurrenceIntervalEnum
    {
        [Display(Name = "Mensal")]
        [EnumMember(Value = "monthly")]
        Monthly = 1,

        [Display(Name = "Bimestral")]
        [EnumMember(Value = "bimonthly")]
        Bimonthly = 2,

        [Display(Name = "Trimestral")]
        [EnumMember(Value = "quarterly")]
        Quarterly = 3,

        [Display(Name = "Semestral")]
        [EnumMember(Value = "semi_annual")]
        SemiAnnual = 6,

        [Display(Name = "Anual")]
        [EnumMember(Value = "annual")]
        Annual = 12
    }
}
