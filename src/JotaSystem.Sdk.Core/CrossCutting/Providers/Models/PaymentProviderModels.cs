using JotaSystem.Sdk.Core.CrossCutting.Providers.Enum;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers.Models
{
    public sealed record PaymentProviderRequest(
        string ProviderKey,
        string IdempotencyKey,
        string Reference,
        decimal Amount,
        string Currency,
        string MethodCode,
        int InstallmentCount,
        PaymentCustomer Customer,
        Uri? CallbackUrl = null,
        Uri? ReturnUrl = null,
        DateTimeOffset? ExpiresAt = null,
        IReadOnlyDictionary<string, string>? Metadata = null);

    public sealed record PaymentCustomer(
        string Name,
        string? Document = null,
        string? Email = null,
        string? Phone = null);

    public sealed record PaymentProviderQuery(string ProviderKey, string TransactionId, string? Reference = null);

    public sealed record PaymentProviderOperation(string ProviderKey, string TransactionId, string? Reason = null);

    public sealed record PaymentProviderRefund(
        string ProviderKey,
        string TransactionId,
        decimal? Amount = null,
        string? Reason = null);

    public sealed record PaymentProviderResult(
        bool IsSuccess,
        PaymentProviderStatusEnum Status,
        string? TransactionId = null,
        string? Reference = null,
        Uri? PaymentUrl = null,
        string? QrCode = null,
        string? Barcode = null,
        decimal? Amount = null,
        string? Currency = null,
        DateTimeOffset? ExpiresAt = null,
        string? Message = null,
        string? RawPayload = null,
        IReadOnlyDictionary<string, string>? Metadata = null);

    public sealed record PaymentWebhookRequest(
        string ProviderKey,
        string Payload,
        IReadOnlyDictionary<string, string> Headers,
        string? WebhookSecret = null);

    public sealed record PaymentWebhookEvent(
        string ProviderKey,
        string EventId,
        string EventType,
        string TransactionId,
        PaymentProviderStatusEnum Status,
        decimal? Amount,
        string? Currency,
        DateTimeOffset OccurredAt,
        string RawPayload,
        IReadOnlyDictionary<string, string>? Metadata = null);
}
