using MediatR;

using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Application.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}

