using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotaSystem.Sdk.Core.Util.Models
{
    /// <summary>
    /// Resultado de operação com payload (genérico).
    /// </summary>
    /// <typeparam name="T">Tipo do valor retornado</typeparam>
    public class OperationResult<T>
    {
        /// <summary>
        /// Indica sucesso.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Valor retornado (when Success is true).
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Mensagem opcional (erro ou descrição).
        /// </summary>
        public string? Message { get; }

        public OperationResult(bool success, T? value = default, string? message = null)
        {
            Success = success;
            Value = value;
            Message = message;
        }

        public static OperationResult<T> Ok(T value, string? message = null) => new(true, value, message);
        public static OperationResult<T> Fail(string message) => new(false, default, message);
    }
}
