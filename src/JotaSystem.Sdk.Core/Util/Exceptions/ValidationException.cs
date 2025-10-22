namespace JotaSystem.Sdk.Core.Util.Exceptions
{
    /// <summary>
    /// Exceção usada para erros de validação.
    /// </summary>
    public class ValidationException : CoreException
    {
        public string? Field { get; }

        public ValidationException(string message, string? field = null)
            : base(message)
        {
            Field = field;
        }
    }
}