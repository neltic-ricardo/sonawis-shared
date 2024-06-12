using MediatR;

using Sonawis.Shared.Domain;

namespace Sonawis.Shared.Application.Messaging;
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}
