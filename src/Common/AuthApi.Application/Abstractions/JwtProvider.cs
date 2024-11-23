using AuthApi.Application.Abstractions.Consts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Application.Abstractions;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    private readonly IPermissionService _permissionService;

    public JwtProvider(IOptions<JwtOptions> options, IPermissionService permissionService)
    {
        _options = options.Value;
        _permissionService = permissionService;
    }

    public async Task<string> GenerateAsync(Domain.Models.Member member)
    {
        List<Claim> claims = new()
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

        var permissions = await _permissionService.GetPermissionsAsync(member.Id);

        foreach (var permission in permissions)
        {
            claims.Add(new(CustomClaims.Permissions, permission));
        }

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
