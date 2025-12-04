namespace JotaSystem.Sdk.Core.CrossCutting.Settings
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; } = new();
        public SerilogSettings Serilog { get; set; } = new();
        public PaymentSettings Payment { get; set; } = new();
        public EmailSettings Email { get; set; } = new();
        public SmsSettings Sms { get; set; } = new();
    }
}