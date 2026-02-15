namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Requests
{
    public sealed record StorageDeleteFileRequest(
        string Key,
        FileAccessLevel AccessLevel = FileAccessLevel.Private);
}
