using AuthApi.Application.Member.Commands.Login;
using Carter;
using Mapster;
using MediatR;

namespace AuthApi.App.Endpoints.Auth.Login;

public record LoginRequest(string Email);
public record LoginResponse(string Token);

public class LoginEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/login", async (LoginRequest request, ISender sender) =>
        {
            var command = request.Adapt<LoginCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<LoginResponse>();

            return Results.Ok(response);
        })
        .WithName("login-account")
        .Produces<LoginResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Authenticate the user")
        .WithDescription("This endpoint sends a request to get a json web token authenticate himself.");
    }
}
