using JotaSystem.Sdk.Core.Application.Results;
using MediatR;

namespace JotaSystem.Sdk.Core.Application.Commands
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>;
}