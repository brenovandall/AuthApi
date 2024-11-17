using AuthApi.App;
using AuthApi.App.OptionsSetup;
using AuthApi.Application;
using AuthApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services
    .AddAppServices()
    .AddApplicationServices()
    .AddInfraServices(builder.Configuration);

var app = builder.Build();

app.UseAppServices();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthentication();

app.Run();
