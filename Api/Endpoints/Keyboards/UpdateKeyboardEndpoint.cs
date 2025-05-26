using Ardalis.Result;
using Carter;
using Domain.Responses.Keyboards;
using Service.Keyboards;

namespace Api.Endpoints.Keyboards;

public class UpdateKeyboardEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "api/keyboards",
                async (
                    IKeyboardService keyboardService,
                    UpdateKeyboardRequest updateKeyboardRequest
                ) =>
                {
                    Result<CreateKeyboardResponse> result = await keyboardService.UpdateKeyboard(
                        updateKeyboardRequest.KeyboardId,
                        updateKeyboardRequest.CategoryId,
                        updateKeyboardRequest.Name,
                        updateKeyboardRequest.Description,
                        updateKeyboardRequest.Price,
                        updateKeyboardRequest.Images,
                        updateKeyboardRequest.Discount
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Update keyboard by id")
            .WithTags("Keyboards");
    }

    public record UpdateKeyboardRequest(
        Guid KeyboardId,
        Guid CategoryId,
        string Name,
        string Description,
        decimal Price,
        string[] Images,
        decimal? Discount = 0
    );
}
