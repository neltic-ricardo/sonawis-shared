using MediatR;

using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Application.Messaging;
public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
