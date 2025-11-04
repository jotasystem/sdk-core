namespace JotaSystem.Sdk.Core.CrossCutting.Exceptions
{
    public class CustomException(string title, string message) : Exception(message)
    {
        public string Title { get; } = title;
    }
}