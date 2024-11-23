using AuthApi.Domain.Abstractions;
using AuthApi.Domain.Enums;
using AuthApi.Domain.Events;
using AuthApi.Domain.ValueObjects;

namespace AuthApi.Domain.Models;

public class Member : Aggregate<MemberId>
{
    public Email Email { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Plan Plan { get; private set; }
    public ICollection<Role> Roles { get; set; } = [];

    public static Member Create(MemberId id, Email email, FirstName firstName, LastName lastName, Plan plan)
    {
        var member = new Member { Id = id, Email = email, FirstName = firstName, LastName = lastName, CreatedAt = DateTime.Now, LastUpdateAt = DateTime.Now };

        member.AddDomainEvent(new MemberCreatedEvent(member));

        return member;
    }

    public void UpdateEmail(Email email)
    {
        Email = email;
    }
}
