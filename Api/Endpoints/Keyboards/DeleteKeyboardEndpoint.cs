using Ardalis.Result;
using Carter;
using Domain.Responses.Keyboards;
using Service.Keyboards;

namespace Api.Endpoints.Keyboards;

public class DeleteKeyboardEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "api/keyboards/{keyboardId}",
                async (IKeyboardService keyboardService, Guid keyboardId) =>
                {
                    Result<GetKeyboardsResponse> result = await keyboardService.DeleteKeyboard(
                        keyboardId
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Delete keyboard by id")
            .WithTags("Keyboards");
    }
}
