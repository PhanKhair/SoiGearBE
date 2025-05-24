using Ardalis.Result;
using Carter;
using Domain.Responses.Categories;
using Service.Categories;

namespace Api.Endpoints.Categories;

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "api/categories/",
                async (
                    ICategoryService categoryService,
                    int index = 1,
                    int size = 10,
                    string search = ""
                ) =>
                {
                    Result<IEnumerable<GetCategoriesResponse>> result =
                        await categoryService.GetCategories(index, size, search);
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get all the categories")
            .WithTags("Categories");

        app.MapGet(
                "api/categories/{categoryId}",
                async (ICategoryService categoryService, Guid categoryId) =>
                {
                    Result<GetCategoriesResponse> result = await categoryService.GetCategoryById(
                        categoryId
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get category by id")
            .WithTags("Categories");
    }
}
