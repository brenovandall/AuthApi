using AuthApi.Application.Data;
using AuthApi.Application.Mappings;
using BuildingBlocks.CQRS;

namespace AuthApi.Application.Member.Queries.GetMembers;

public class GetMembersQueryHandler(IReadDbContext _readContext)
    : IQueryHandler<GetMembersQuery, GetMembersResult>
{
    public async Task<GetMembersResult> Handle(GetMembersQuery query, CancellationToken cancellationToken)
    {
        var members = _readContext.Members.ToList();

        return new GetMembersResult(members.ToMemberDtoList());
    }
}
