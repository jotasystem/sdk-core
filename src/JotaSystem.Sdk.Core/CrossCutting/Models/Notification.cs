namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    public class Notification(string field, string key, params object[] messageArgs)
    {
        public string Field { get; } = field;
        public string Key { get; } = key;
        public object[] MessageArgs { get; } = messageArgs;
    }
}