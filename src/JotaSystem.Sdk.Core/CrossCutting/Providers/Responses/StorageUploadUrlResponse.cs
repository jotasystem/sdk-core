namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Responses
{    
    public sealed record StorageUploadUrlResponse(
       Uri Url,
       string Method,
       DateTimeOffset ExpiresAt,
       IReadOnlyDictionary<string, string> Headers,
       IReadOnlyDictionary<string, string> Fields);
}