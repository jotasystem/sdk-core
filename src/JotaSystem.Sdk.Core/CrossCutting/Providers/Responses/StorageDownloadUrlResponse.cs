namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Responses
{
    public sealed record StorageDownloadUrlResponse(
        Uri Url,
        DateTimeOffset? ExpiresAt,
        bool IsSigned);
}
