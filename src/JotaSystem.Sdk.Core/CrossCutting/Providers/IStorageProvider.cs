using JotaSystem.Sdk.Core.CrossCutting.Providers.Requests;
using JotaSystem.Sdk.Core.CrossCutting.Providers.Responses;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IStorageProvider
    {
        Task<StorageUploadResponse> UploadAsync(StorageUploadRequest request, CancellationToken cancellationToken = default);
        Task<StorageDownloadResponse> DownloadAsync(string path, CancellationToken cancellationToken = default);
        Task DeleteAsync(string path, CancellationToken cancellationToken = default);
        Task<StorageFileInfoResponse?> GetAsync(string path, CancellationToken cancellationToken = default);
        Task<string> GetUrlAsync(string path, CancellationToken cancellationToken = default);
    }
}