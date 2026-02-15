
namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Requests
{
    public sealed record StorageDownloadUrlRequest(
        string Key,
        FileAccessLevel AccessLevel = FileAccessLevel.Private,
        TimeSpan? ExpiresIn = null,
        string? FileName = null,
        string? ContentDisposition = null);

}
