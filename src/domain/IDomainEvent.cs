using MediatR;

namespace Sonawis.Shared.Domain;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}

