using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class OtpSetting
    {
        [Required] public string Issuer { get; set; } = string.Empty;
        [Range(6, 8)] public int Digits { get; set; } = 6;
        [Range(15, 300)] public int StepSeconds { get; set; } = 30;

        /// <summary>
        /// Quantidade de steps de tolerância aceitos antes e depois do atual, para compensar
        /// diferença de relógio entre servidor e dispositivo. Cada step a mais amplia a janela
        /// de aceitação do código — mantenha o menor valor que funcione.
        /// </summary>
        [Range(0, 10)] public int VerificationWindow { get; set; } = 1;
    }
}
