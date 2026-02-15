
namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Requests
{
    public sealed record StorageUploadUrlRequest(
        string Key,
        string ContentType,
        long ContentLength,
        FileAccessLevel AccessLevel = FileAccessLevel.Private,
        TimeSpan? ExpiresIn = null,
        string? FileName = null,
        string? ContentDisposition = null,
        IReadOnlyDictionary<string, string>? Metadata = null,
        IReadOnlyDictionary<string, string>? Tags = null);
}