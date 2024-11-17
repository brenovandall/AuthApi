using AuthApi.Application.Dtos;
using AuthApi.Application.Member.Commands.CreateMember;
using Carter;
using Mapster;
using MediatR;

namespace AuthApi.App.Endpoints.CreateMember;

public record CreateMemberRequest(MemberDto MemberDto);
public record CreateMemberResponse(Guid Id);

public class CreateMemberEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/members", async (CreateMemberRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateMemberCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateMemberResult>();

            return Results.Created($"members/{response.Id}", response);
        })
        .WithName("create-member")
        .RequireAuthorization()
        .Produces<CreateMemberResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Proccess to create a new member")
        .WithDescription("This endpoint sends a request to create a new member, and it returns the ID of the member created.");
    }
}
