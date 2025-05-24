using Ardalis.Result;
using Carter;
using Domain.Responses.Switches;
using Service.Switches;

namespace Api.Endpoints.Switches;

public class GetSwitchesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "api/switches/",
                async (
                    ISwitchService switchService,
                    int index = 1,
                    int size = 10,
                    string search = "",
                    string category = "",
                    bool status = true
                ) =>
                {
                    Result<IEnumerable<GetSwitchesResponse>> result =
                        await switchService.GetSwitches(index, size, search, category, status);
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get all the switches")
            .WithTags("Switches");

        app.MapGet(
                "api/switches/{switchId}",
                async (ISwitchService switchService, Guid switchId) =>
                {
                    Result<GetSwitchesResponse> result = await switchService.GetSwitchById(
                        switchId
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get switch by id")
            .WithTags("Switches");
    }
}
