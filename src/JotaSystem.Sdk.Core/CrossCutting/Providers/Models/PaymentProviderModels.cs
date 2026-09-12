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

    /// <summary>
    /// Configuração da integração usada na chamada ao gateway.
    /// </summary>
    /// <param name="Secrets">
    /// Credenciais já decifradas da integração do tenant, por nome (ex.: <c>merchantKey</c>,
    /// <c>clientSecret</c>). Cada gateway documenta as chaves que consome e completa o que
    /// faltar com a configuração padrão da aplicação.
    /// </param>
    public sealed record PaymentProviderContext(
        string Environment,
        string? PublicConfigJson = null,
        string? SecretReference = null,
        string? WebhookSecretReference = null,
        IReadOnlyDictionary<string, string>? Secrets = null);

    /// <summary>
    /// Meio de pagamento oferecido por um gateway, usado para configurar a forma de
    /// pagamento sem que o operador precise decorar códigos.
    /// </summary>
    /// <param name="RequiresCard">
    /// Indica que a cobrança só é aceita com os dados do cartão, capturados no navegador
    /// pelo checkout do gateway. Quem opera a cobrança usa isso para pedir o cartão antes
    /// de chamar o gateway.
    /// </param>
    public sealed record PaymentMethodOption(
        string Code,
        string Name,
        string? Description = null,
        bool RequiresCard = false);

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
    /// Dados do cartao usados na cobranca, em ordem de preferencia:
    /// <see cref="SingleUseToken"/>, gerado no navegador do comprador pelo script do gateway;
    /// <see cref="Token"/>, de um cartao ja armazenado no cofre do gateway;
    /// ou, em ultimo caso, os dados completos do cartao.
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
        bool SaveCard = false,
        string? SingleUseToken = null)
    {
        private const int VisiblePrefixLength = 6;
        private const int VisibleSuffixLength = 4;

        /// <summary>Indica que a cobranca usa um token no lugar dos dados do cartao.</summary>
        public bool IsTokenized =>
            !string.IsNullOrWhiteSpace(Token) || !string.IsNullOrWhiteSpace(SingleUseToken);

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

    /// <summary>
    /// Pedido de abertura de uma sessao de checkout no gateway. A sessao autoriza o
    /// script do gateway, no navegador do comprador, a receber os dados do cartao e
    /// devolver um token de uso unico.
    /// </summary>
    public sealed record PaymentCheckoutSessionRequest(
        string ProviderKey,
        decimal? Amount = null,
        string? Currency = null,
        string? Reference = null,
        PaymentProviderContext? Context = null);

    /// <summary>
    /// Sessao de checkout aberta no gateway. Entregue <see cref="AccessToken"/>,
    /// <see cref="ScriptUrl"/> e <see cref="Environment"/> ao navegador; nenhum desses
    /// valores da acesso a operacoes na conta do lojista.
    /// </summary>
    public sealed record PaymentCheckoutSession(
        bool IsSuccess,
        string? AccessToken = null,
        string? ScriptUrl = null,
        string? Environment = null,
        DateTimeOffset? ExpiresAt = null,
        string? Message = null,
        IReadOnlyDictionary<string, string>? Metadata = null);

    /// <param name="MethodCode">
    /// Meio de pagamento usado na criação da cobrança. Gateways que atendem mais de uma API
    /// pelo mesmo <c>ProviderKey</c> dependem dele para consultar a transação na API certa.
    /// </param>
    public sealed record PaymentProviderQuery(
        string ProviderKey,
        string TransactionId,
        string? Reference = null,
        PaymentProviderContext? Context = null,
        string? MethodCode = null);

    /// <inheritdoc cref="PaymentProviderQuery" path="/param[@name='MethodCode']"/>
    public sealed record PaymentProviderOperation(
        string ProviderKey,
        string TransactionId,
        string? Reason = null,
        PaymentProviderContext? Context = null,
        string? MethodCode = null);

    /// <inheritdoc cref="PaymentProviderQuery" path="/param[@name='MethodCode']"/>
    public sealed record PaymentProviderRefund(
        string ProviderKey,
        string TransactionId,
        decimal? Amount = null,
        string? Reason = null,
        PaymentProviderContext? Context = null,
        string? MethodCode = null);

    /// <param name="QrCode">Código copia e cola do Pix, quando o meio de pagamento gera um.</param>
    /// <param name="QrCodeImage">
    /// Imagem do QR Code em base64, como o gateway devolveu e sem o prefixo <c>data:</c>.
    /// Acompanha o <paramref name="QrCode"/> nos gateways que já renderizam o código.
    /// </param>
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
        IReadOnlyDictionary<string, string>? Metadata = null,
        string? QrCodeImage = null);

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
