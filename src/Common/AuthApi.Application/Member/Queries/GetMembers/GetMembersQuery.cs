using AuthApi.Application.Dtos;
using BuildingBlocks.CQRS;

namespace AuthApi.Application.Member.Queries.GetMembers;

public record GetMembersQuery() : IQuery<GetMembersResult>;
public record GetMembersResult(IEnumerable<MemberDto> Members);
