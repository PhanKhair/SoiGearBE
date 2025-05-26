using Ardalis.Result;
using Carter;
using Domain.Responses.Keyboards;
using Service.Keyboards;

namespace Api.Endpoints.Keyboards;

public class CreateKeyboardEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "api/keyboards",
                async (
                    IKeyboardService keyboardService,
                    CreateKeyboardRequest createKeyboardRequest
                ) =>
                {
                    Result<CreateKeyboardResponse> result = await keyboardService.AddKeyboard(
                        createKeyboardRequest.CategoryId,
                        createKeyboardRequest.Name,
                        createKeyboardRequest.Description,
                        createKeyboardRequest.Price,
                        createKeyboardRequest.Images,
                        createKeyboardRequest.Discount
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Create new keyboard")
            .WithTags("Keyboards");
    }

    public record CreateKeyboardRequest(
        Guid CategoryId,
        string Name,
        string Description,
        decimal Price,
        string[] Images,
        decimal? Discount = 0
    );
}
