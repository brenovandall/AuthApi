using AuthApi.Application.Data;
using AuthApi.Domain.Events;
using MediatR;

namespace AuthApi.Application.Member.EventHandlers;

public class MemberCreatedEventHandler(IReadDbContext _readContext)
    : INotificationHandler<MemberCreatedEvent>
{
    public async Task Handle(MemberCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.member is null)
            throw new ArgumentNullException(nameof(notification.member));

        _readContext.Members.Add(notification.member);
        await _readContext.SaveChangesAsync(cancellationToken);
    }
}
