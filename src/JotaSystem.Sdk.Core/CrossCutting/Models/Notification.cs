namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    public class Notification(string key, string field, params object[] message)
    {
        public string Key { get; } = key;
        public string Field { get; } = field;
        public object[] Message { get; } = message;
    }
}