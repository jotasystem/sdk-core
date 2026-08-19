namespace JotaSystem.Sdk.Core.CrossCutting.Security
{
    /// <summary>
    /// Geração e validação de códigos OTP (One-Time Password) baseados em tempo (TOTP).
    /// </summary>
    public interface IOtpService
    {
        /// <summary>
        /// Gera um novo segredo em Base32, para ser persistido e associado ao usuário.
        /// </summary>
        string GenerateSecret();

        /// <summary>
        /// Gera o código válido para o instante atual a partir do segredo informado.
        /// </summary>
        (string Code, int ExpiresIn, DateTime ExpiresAt) GenerateCode(string secret);

        /// <summary>
        /// Valida o código informado, respeitando a janela de tolerância configurada.
        /// </summary>
        bool ValidateCode(string secret, string code);

        /// <summary>
        /// Monta a URI otpauth:// consumida por aplicativos autenticadores (Google Authenticator, Authy).
        /// </summary>
        string BuildAuthenticatorUri(string secret, string account);
    }
}
