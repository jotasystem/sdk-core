using JotaSystem.Sdk.Core.CrossCutting.Providers.Enum;
using System.ComponentModel.DataAnnotations;

namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class StorageSetting
    {
        [Required]
        public StorageProviderEnum Provider { get; set; }
        public AzureBlobSetting? AzureBlob { get; set; }

        public class AzureBlobSetting
        {
            [Required] public string ConnectionString { get; set; } = default!;
            [Required] public string ContainerName { get; set; } = default!;
        }
    }
}