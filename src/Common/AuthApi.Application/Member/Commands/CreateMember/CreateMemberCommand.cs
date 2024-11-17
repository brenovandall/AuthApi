using AuthApi.Application.Dtos;
using BuildingBlocks.CQRS;

namespace AuthApi.Application.Member.Commands.CreateMember;

public record CreateMemberCommand(MemberDto MemberDto) : ICommand<CreateMemberResult>;
public record CreateMemberResult(Guid Id);
