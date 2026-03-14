
namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Requests
{
    public sealed class StorageUploadRequest
    {
        public Stream Content { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string ContentType { get; set; } = "application/octet-stream";
        public string Container { get; set; } = default!;
        public string? Folder { get; set; }
        public bool Overwrite { get; set; }
    }
}