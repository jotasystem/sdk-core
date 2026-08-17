using JotaSystem.Sdk.Core.CrossCutting.Providers.Models;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IPaymentProvider
    {
        Task<PaymentProviderResult> CreateAsync(PaymentProviderRequest request, CancellationToken cancellationToken = default);
        Task<PaymentProviderResult> GetAsync(PaymentProviderQuery query, CancellationToken cancellationToken = default);
        Task<PaymentProviderResult> CancelAsync(PaymentProviderOperation operation, CancellationToken cancellationToken = default);
        Task<PaymentProviderResult> RefundAsync(PaymentProviderRefund operation, CancellationToken cancellationToken = default);
        Task<PaymentWebhookEvent> ParseWebhookAsync(PaymentWebhookRequest request, CancellationToken cancellationToken = default);
    }
}
