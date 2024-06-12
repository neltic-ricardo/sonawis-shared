using MediatR;

using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
