using Ardalis.Result;
using Carter;
using Domain.Responses.Users;
using Service.Users;

namespace Api.Endpoints.Users;

public class GetUsersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "api/users/",
                async (
                    IUserService userService,
                    int index = 1,
                    int size = 10,
                    string search = "",
                    string email = "",
                    string role = "",
                    bool status = true
                ) =>
                {
                    Result<IEnumerable<GetUsersResponse>> result = await userService.GetUsers(
                        index,
                        size,
                        search,
                        email,
                        role,
                        status
                    );
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get all the users")
            .WithTags("Users");

        app.MapGet(
                "api/users/{userId}",
                async (IUserService userService, Guid userId) =>
                {
                    Result<GetUsersResponse> result = await userService.GetUserById(userId);
                    if (!result.IsSuccess)
                    {
                        return Results.NotFound(result);
                    }

                    return Results.Ok(result);
                }
            )
            .WithSummary("Get user by id")
            .WithTags("Users");
    }
}
