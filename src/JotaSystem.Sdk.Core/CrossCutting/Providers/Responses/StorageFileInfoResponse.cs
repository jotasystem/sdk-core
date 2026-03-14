namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Responses
{
    public sealed class StorageFileInfoResponse
    {
        public string FileName { get; set; } = default!;
        public string Path { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string ContentType { get; set; } = "application/octet-stream";
        public long? Size { get; set; }
        public bool Exists { get; set; }
    }
}