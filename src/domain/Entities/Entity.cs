using MediatR;

namespace Sonawis.Shared.Domain.Entities;

public abstract class Entity : AuditableEntity, IEquatable<Entity>
{
    protected Entity(int id) => Id = id;

    protected Entity()
    {
    }

    public int Id { get; private init; }


    private List<INotification> _domainEvents = new List<INotification>();
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return Id == default;
    }


    public static bool operator ==(Entity? first, Entity? second) =>
        first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity? first, Entity? second) =>
        !(first == second);

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode() => Id.GetHashCode() * 41;
}
