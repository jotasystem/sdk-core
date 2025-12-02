using JotaSystem.Sdk.Core.CrossCutting.Models;

namespace JotaSystem.Sdk.Core.Application.Results
{
    public class ResultFactoryExtensions
    {
        /// <summary>
        /// Cria dinamicamente um Result ou Result<T> conforme o tipo TResponse.
        /// Compatível com Behaviors do MediatR.
        /// </summary>
        public static TResponse CreateBadRequestResponse<TResponse>(string message, List<Notification>? errors = null)
        {
            var responseType = typeof(TResponse);

            // Caso seja Result<T>
            if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var innerType = responseType.GetGenericArguments()[0];

                var method = typeof(ResultFactory)
                    .GetMethods()
                    .Where(m => m.Name == nameof(ResultFactory.BadRequest))
                    .Where(m => m.IsGenericMethodDefinition)
                    .Single();

                var genericMethod = method.MakeGenericMethod(innerType);

                var result = genericMethod.Invoke(null, [message, errors]);

                return (TResponse)result!;
            }

            // Caso seja Result simples
            if (responseType == typeof(Result))
            {
                return (TResponse)(object)ResultFactory.BadRequest(message, errors);
            }

            // Tipo inválido
            throw new InvalidOperationException(
                $"CreateBadRequestResponse só funciona com Result ou Result<T>. TResponse recebido: {responseType.Name}");
        }
    }
}