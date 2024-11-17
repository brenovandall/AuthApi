namespace AuthApi.Domain.Abstractions;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDominEvent> DominEvents { get; }
    IDominEvent[] ClearDomainEvents();
}
