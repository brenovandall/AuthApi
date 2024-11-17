using BuildingBlocks.CQRS;

namespace AuthApi.Application.Member.Commands.Login;

public record LoginCommand(string Email) : ICommand<LoginResult>;
public record LoginResult(string Token);
