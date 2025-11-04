namespace JotaSystem.Sdk.Core.CrossCutting.Models
{
    /// <summary>
    /// Resultado simples de operação (sem valor).
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Indica sucesso.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Mensagem opcional (erro ou descrição).
        /// </summary>
        public string? Message { get; }

        public OperationResult(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }

        public static OperationResult Ok(string? message = null) => new(true, message);
        public static OperationResult Fail(string message) => new(false, message);
    }
}