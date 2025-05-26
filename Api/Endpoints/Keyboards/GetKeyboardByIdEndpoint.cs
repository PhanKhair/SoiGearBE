using Ardalis.Result;
using Carter;
using Domain.Responses.Keyboards;
using Service.Keyboards;

namespace Api.Endpoints.Keyboards;

public class GetKeyboardByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "api/keyboards/{keyboardId}",
                async (IKeyboardService keyboardService, Guid keyboardId) =>
                {
                    Result<GetKeyboardsResponse> result = await keyboardService.GetKeyboardById(
                        keyboardId
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get keyboard by id")
            .WithTags("Keyboards");
    }
}
