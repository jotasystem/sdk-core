namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Responses
{
    public sealed class StorageDownloadResponse : IDisposable
    {
        public Stream Content { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string ContentType { get; set; } = "application/octet-stream";
        public long? Size { get; set; }

        public void Dispose()
        {
            Content?.Dispose();
        }
    }
}