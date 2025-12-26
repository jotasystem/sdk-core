using JotaSystem.Sdk.Core.CrossCutting.Providers;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class AiSettings
    {
        [Required]
        public AiProviderType Provider { get; set; } = AiProviderType.OpenAi;

        // Configurações específicas de cada provider
        public OpenAiSetting? OpenAi { get; set; }

        // 🔹 Subclasses para cada provider
        public class OpenAiSetting
        {
            [Required] public string ApiKey { get; set; } = string.Empty;
            [Required] public string Model { get; set; } = "gpt-4o-mini";
        }
    }
}