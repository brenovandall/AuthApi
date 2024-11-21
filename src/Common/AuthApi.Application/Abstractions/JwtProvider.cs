using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Application.Abstractions;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(Domain.Models.Member member)
    {
        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Iss, _options.Issuer),
            new(JwtRegisteredClaimNames.Nbf, DateTime.Now.GetHashCode().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTime.Now.GetHashCode().ToString()),
            new(JwtRegisteredClaimNames.Exp, DateTime.Now.AddHours(1).GetHashCode().ToString()),
            new(JwtRegisteredClaimNames.Amr, "pwd"),
            new(JwtRegisteredClaimNames.Sub, member.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.AuthTime, DateTime.Now.GetHashCode().ToString()),
            new(JwtRegisteredClaimNames.Sid, Guid.NewGuid().ToString().ToUpper().Replace("-", "")),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString().ToUpper())
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
