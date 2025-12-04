using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public enum StorageProviderType
    {
        [Display(Name = "AWS S3")]
        [EnumMember(Value = "aws_s3")]
        AwsS3 = 0,

        [Display(Name = "Azure Blob Storage")]
        [EnumMember(Value = "azure_blob")]
        AzureBlob = 1,

        [Display(Name = "Google Cloud Storage")]
        [EnumMember(Value = "google_cloud")]
        GoogleCloud = 2,

        [Display(Name = "Local Storage")]
        [EnumMember(Value = "local")]
        Local = 3
    }
}