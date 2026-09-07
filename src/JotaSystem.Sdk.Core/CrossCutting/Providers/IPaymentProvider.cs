using JotaSystem.Sdk.Core.CrossCutting.Providers.Models;

namespace JotaSystem.Sdk.Core.CrossCutting.Providers
{
    public interface IPaymentProvider
    {
        /// <summary>
        /// Meios de pagamento oferecidos pelo gateway, para montar a configuração da forma
        /// de pagamento. Devolve vazio quando o gateway não publica esse catálogo.
        /// </summary>
        IReadOnlyList<PaymentMethodOption> GetSupportedMethods(string providerKey) => [];

        /// <summary>
        /// Abre uma sessao de checkout para que o navegador do comprador envie os dados do
        /// cartao direto ao gateway e devolva um token de uso unico. Gateways sem suporte a
        /// captura no navegador devolvem <c>IsSuccess</c> falso.
        /// </summary>
        Task<PaymentCheckoutSession> CreateCheckoutSessionAsync(
            PaymentCheckoutSessionRequest request,
            CancellationToken cancellationToken = default) =>
            Task.FromResult(new PaymentCheckoutSession(
                false,
                Message: "O gateway selecionado nao oferece captura de cartao no navegador."));

        Task<PaymentProviderResult> CreateAsync(PaymentProviderRequest request, CancellationToken cancellationToken = default);
        Task<PaymentProviderResult> GetAsync(PaymentProviderQuery query, CancellationToken cancellationToken = default);
        Task<PaymentProviderResult> CancelAsync(PaymentProviderOperation operation, CancellationToken cancellationToken = default);
        Task<PaymentProviderResult> RefundAsync(PaymentProviderRefund operation, CancellationToken cancellationToken = default);
        Task<PaymentWebhookEvent> ParseWebhookAsync(PaymentWebhookRequest request, CancellationToken cancellationToken = default);
    }
}
