
namespace AuthApi.Domain.Abstractions;

public class Aggregate<Tid> : Entity<Tid>, IAggregate<Tid>
{
    private readonly List<IDominEvent> _domainEvents = [];
    public IReadOnlyList<IDominEvent> DominEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDominEvent dominEvent) => _domainEvents.Add(dominEvent);

    public IDominEvent[] ClearDomainEvents()
    {
        IDominEvent[] dequeuedDomainEvents = _domainEvents.ToArray();
        _domainEvents.Clear();

        return dequeuedDomainEvents;
    }
}
