namespace AuthApi.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(Domain.Models.Member member);
}
