using Ardalis.Result;
using Carter;
using Domain.Responses.Keyboards;
using Service.Keyboards;

namespace Api.Endpoints.Keyboards;

public class GetKeyboardsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "api/keyboards/",
                async (
                    IKeyboardService keyboardService,
                    int index = 1,
                    int size = 10,
                    string search = "",
                    string category = "",
                    bool status = true
                ) =>
                {
                    Result<IEnumerable<GetKeyboardsResponse>> result =
                        await keyboardService.GetKeyboards(index, size, search, category, status);
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get all the keyboards")
            .WithTags("Keyboards");

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
