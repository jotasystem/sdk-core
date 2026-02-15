namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Requests
{
    public sealed record StorageMoveFileRequest(
        string SourceKey,
        string DestinationKey,
        FileAccessLevel AccessLevel = FileAccessLevel.Private,
        bool Overwrite = false);
}
