using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    public enum AiProviderEnum
    {
        [Display(Name = "OpenAI")]
        [EnumMember(Value = "openai")]
        OpenAi = 0,

        [Display(Name = "Google Vertex AI")]
        [EnumMember(Value = "google_vertex")]
        GoogleVertex = 1,

        [Display(Name = "AWS SageMaker")]
        [EnumMember(Value = "aws_sagemaker")]
        AwsSageMaker = 2,

        [Display(Name = "Microsoft Cognitive Services")]
        [EnumMember(Value = "microsoft_cognitive")]
        MicrosoftCognitive = 3
    }
}