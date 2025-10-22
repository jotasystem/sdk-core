namespace JotaSystem.Sdk.Core.CrossCutting
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogInformation<T>(string message, T propertyValue);
        void LogWarning(string message);
        void LogError(Exception? ex, string message);
    }
}