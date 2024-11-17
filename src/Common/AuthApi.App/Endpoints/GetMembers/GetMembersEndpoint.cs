using AuthApi.Application.Dtos;
using AuthApi.Application.Member.Queries.GetMembers;
using Carter;
using Mapster;
using MediatR;

namespace AuthApi.App.Endpoints.GetMembers;

//public record GetMembersRequest();
public record GetMembersResponse(IEnumerable<MemberDto> Members);

public class GetMembersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/members", async (ISender sender) =>
        {
            var result = await sender.Send(new GetMembersQuery());

            var response = result.Adapt<GetMembersResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("get-members")
        .Produces<GetMembersResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Proccess to get a list of members")
        .WithDescription("This endpoint sends a request to get a list of members.");
    }
}
