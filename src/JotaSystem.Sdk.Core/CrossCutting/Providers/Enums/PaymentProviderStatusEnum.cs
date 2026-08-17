namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Enum
{
    public enum PaymentProviderStatusEnum
    {
        Pending = 1,
        Authorized = 2,
        Paid = 3,
        Failed = 4,
        Cancelled = 5,
        Refunded = 6,
        Expired = 7,
        Chargeback = 8
    }
}
