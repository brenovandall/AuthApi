using AuthApi.Application.Data;
using AuthApi.Application.Dtos;
using AuthApi.Domain.ValueObjects;
using BuildingBlocks.CQRS;

namespace AuthApi.Application.Member.Commands.CreateMember;

public class CreateMemberCommandHandler (ICommandDbContext _commandContext)
    : ICommandHandler<CreateMemberCommand, CreateMemberResult>
{
    public async Task<CreateMemberResult> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var member = CreateMember(command.MemberDto);

        _commandContext.Members.Add(member);
        await _commandContext.SaveChangesAsync(cancellationToken);

        return new CreateMemberResult(member.Id.Value);
    }

    private Domain.Models.Member CreateMember(MemberDto memberDto)
    {
        return Domain.Models.Member.Create(
            id: MemberId.Of(Guid.NewGuid()),
            email: Email.Of(memberDto.Email),
            firstName: FirstName.Of(memberDto.FirstName),
            lastName: LastName.Of(memberDto.LastName),
            plan: memberDto.Plan);
    }
}
