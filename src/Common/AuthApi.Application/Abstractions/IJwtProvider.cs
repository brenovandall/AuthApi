namespace AuthApi.Application.Abstractions;

public interface IJwtProvider
{
    Task<string> GenerateAsync(Domain.Models.Member member);
}
