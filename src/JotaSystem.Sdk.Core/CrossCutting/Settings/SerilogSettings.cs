using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class SerilogSettings
    {
        public List<string>? Using { get; set; }

        [Required]
        [RegularExpression("Verbose|Debug|Information|Warning|Error|Fatal", ErrorMessage = "O nível de log deve ser: Verbose, Debug, Information, Warning, Error ou Fatal.")]
        public string MinimumLevel { get; set; } = "Information";

        public List<WriteToSetting>? WriteTo { get; set; }
        public List<string>? Enrich { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
    }

    public class WriteToSetting
    {
        [Required]
        public string Name { get; set; } = default!;

        public Dictionary<string, object>? Args { get; set; }
    }
}