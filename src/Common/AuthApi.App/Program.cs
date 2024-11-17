using AuthApi.App;
using AuthApi.App.OptionsSetup;
using AuthApi.Application;
using AuthApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppServices()
    .AddApplicationServices()
    .AddInfraServices(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

var app = builder.Build();

app.UseAppServices();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
