using JotaSystem.Sdk.Core.CrossCutting.Providers.Enum;
using System.Text.Json.Serialization;

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
        IReadOnlyDictionary<string, string>? Metadata = null,
        PaymentProviderContext? Context = null,
        PaymentCard? Card = null,
        PaymentRecurrence? Recurrence = null);

    public sealed record PaymentProviderContext(
        string Environment,
        string? PublicConfigJson = null,
        string? SecretReference = null,
        string? WebhookSecretReference = null);

    public sealed record PaymentCustomer(
        string Name,
        string? Document = null,
        string? Email = null,
        string? Phone = null,
        PaymentAddress? Address = null,
        DateOnly? Birthdate = null);

    /// <summary>
    /// Endereco do pagador. Exigido pelos meios de pagamento registrados, como boleto.
    /// </summary>
    public sealed record PaymentAddress(
        string? Street = null,
        string? Number = null,
        string? Complement = null,
        string? District = null,
        string? ZipCode = null,
        string? City = null,
        string? State = null,
        string? Country = "BRA");

    /// <summary>
    /// Dados do cartao usados na cobranca. Informe <see cref="Token"/> quando o cartao ja
    /// estiver tokenizado no gateway; caso contrario, informe os dados completos.
    /// </summary>
    /// <remarks>
    /// O numero e o codigo de seguranca nao sao serializados e nao aparecem no
    /// <c>ToString</c>: eles nao podem ser gravados em log, auditoria ou payload
    /// persistido. Use <see cref="MaskedNumber"/> para rastreabilidade.
    /// </remarks>
    public sealed record PaymentCard(
        string? Token = null,
        [property: JsonIgnore] string? Number = null,
        string? Holder = null,
        string? ExpirationDate = null,
        [property: JsonIgnore] string? SecurityCode = null,
        string? Brand = null,
        bool SaveCard = false)
    {
        private const int VisiblePrefixLength = 6;
        private const int VisibleSuffixLength = 4;

        /// <summary>Indica que a cobranca usa um cartao ja tokenizado no gateway.</summary>
        public bool IsTokenized => !string.IsNullOrWhiteSpace(Token);

        /// <summary>Numero do cartao mascarado, seguro para auditoria e para exibicao.</summary>
        public string? MaskedNumber => Mask(Number);

        public override string ToString() =>
            $"PaymentCard {{ Brand = {Brand}, MaskedNumber = {MaskedNumber}, IsTokenized = {IsTokenized} }}";

        private static string? Mask(string? number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return null;

            var digits = new string(number.Where(char.IsDigit).ToArray());
            if (digits.Length <= VisibleSuffixLength)
                return new string('*', digits.Length);

            var suffix = digits[^VisibleSuffixLength..];
            if (digits.Length <= VisiblePrefixLength + VisibleSuffixLength)
                return $"{new string('*', digits.Length - VisibleSuffixLength)}{suffix}";

            var prefix = digits[..VisiblePrefixLength];
            return $"{prefix}{new string('*', digits.Length - VisiblePrefixLength - VisibleSuffixLength)}{suffix}";
        }
    }

    /// <summary>
    /// Configuracao da cobranca recorrente agendada no gateway.
    /// </summary>
    public sealed record PaymentRecurrence(
        PaymentRecurrenceIntervalEnum Interval = PaymentRecurrenceIntervalEnum.Monthly,
        DateOnly? StartDate = null,
        DateOnly? EndDate = null,
        bool ChargeImmediately = true);

    public sealed record PaymentProviderQuery(
        string ProviderKey,
        string TransactionId,
        string? Reference = null,
        PaymentProviderContext? Context = null);

    public sealed record PaymentProviderOperation(
        string ProviderKey,
        string TransactionId,
        string? Reason = null,
        PaymentProviderContext? Context = null);

    public sealed record PaymentProviderRefund(
        string ProviderKey,
        string TransactionId,
        decimal? Amount = null,
        string? Reason = null,
        PaymentProviderContext? Context = null);

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
        string? WebhookSecret = null,
        PaymentProviderContext? Context = null);

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
