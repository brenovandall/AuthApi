using AuthApi.Application.Abstractions;
using AuthApi.Application.Data;
using AuthApi.Domain.Errors;
using AuthApi.Domain.ValueObjects;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Application.Member.Commands.Login;

public class LoginCommandHandler (IReadDbContext _readContext, IJwtProvider _jwtProvider)
    : ICommandHandler<LoginCommand, LoginResult>
{
    public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        Email? email = Email.Of(command.Email);

        var member = await _readContext.Members
            .FirstOrDefaultAsync(m => m.Email.Equals(email), cancellationToken);

        if (member is null)
            throw new BadRequestException(DomainErrors.Member.InvalidCredentials);

        string token = _jwtProvider.Generate(member);

        return new LoginResult(token);
    }
}
