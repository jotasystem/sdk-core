namespace JotaSystem.Sdk.Core.Application.Auditing
{
    public interface IAuditSerializer
    {
        string? Serialize(object? value);
    }
}