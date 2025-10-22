namespace JotaSystem.Sdk.Core.Util.Exceptions
{
    /// <summary>
    /// Exceção base para erros do Core.
    /// </summary>
    public abstract class CoreException : Exception
    {
        protected CoreException(string message) : base(message) { }

        protected CoreException(string message, Exception innerException) : base(message, innerException) { }
    }
}