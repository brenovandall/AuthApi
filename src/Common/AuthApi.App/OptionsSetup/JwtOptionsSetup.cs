using AuthApi.Application.Abstractions;
using Microsoft.Extensions.Options;

namespace AuthApi.App.OptionsSetup;

public class JwtOptionsSetup (IConfiguration _configuration) : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "Jwt";

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
