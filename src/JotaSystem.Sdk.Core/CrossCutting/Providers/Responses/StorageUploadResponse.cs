namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Responses
{
    public sealed class StorageUploadResponse
    {
        public string FileName { get; set; } = default!;
        public string Path { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long Size { get; set; }
    }
}