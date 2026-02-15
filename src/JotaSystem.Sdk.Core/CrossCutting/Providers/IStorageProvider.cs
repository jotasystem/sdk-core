using JotaSystem.Sdk.Core.CrossCutting.Providers.Requests;
using JotaSystem.Sdk.Core.CrossCutting.Providers.Responses;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IFileStorage
    {
        Task<StorageUploadUrlResponse> GetUploadUrlAsync(StorageUploadUrlRequest request, CancellationToken cancellationToken = default);
        Task<StorageDownloadUrlResponse> GetDownloadUrlAsync(StorageDownloadUrlRequest request, CancellationToken cancellationToken = default);
        Task DeleteAsync(StorageDeleteFileRequest request, CancellationToken cancellationToken = default);
        Task MoveAsync(StorageMoveFileRequest request, CancellationToken cancellationToken = default);
    }

    public enum FileAccessLevel
    {
        Private = 0,
        Public = 1
    }
}