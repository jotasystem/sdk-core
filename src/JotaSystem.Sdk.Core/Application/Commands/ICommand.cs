using JotaSystem.Sdk.Core.Application.Results;
using MediatR;

namespace JotaSystem.Sdk.Core.Application.Commands
{
    public interface ICommand;
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
}