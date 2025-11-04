using JotaSystem.Sdk.Core.Application.Results;
using MediatR;

namespace JotaSystem.Sdk.Core.Application.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>;
}
