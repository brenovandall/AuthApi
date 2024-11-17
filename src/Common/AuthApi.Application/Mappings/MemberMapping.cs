using AuthApi.Application.Dtos;

namespace AuthApi.Application.Mappings;

public static class MemberMapping
{
    public static IEnumerable<MemberDto> ToMemberDtoList(this IEnumerable<Domain.Models.Member> members) =>
        members.Select(m => new MemberDto(
            Id: m.Id.Value,
            Email: m.Email.Value,
            FirstName: m.FirstName.Value,
            LastName: m.LastName.Value,
            Plan: m.Plan));
}
