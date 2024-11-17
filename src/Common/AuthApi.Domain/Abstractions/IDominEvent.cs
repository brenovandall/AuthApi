using MediatR;

namespace AuthApi.Domain.Abstractions;

public interface IDominEvent : INotification
{
    Guid Id => Guid.NewGuid();
    public DateTime? EventOccured => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName!;
}
