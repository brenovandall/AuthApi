using AuthApi.Domain.Enums;

namespace AuthApi.Application.Dtos;

public record MemberDto(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    Plan Plan);
