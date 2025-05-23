using Ardalis.Result;
using Domain.Responses.Users;

namespace Service.Users;

public interface IUserService
{
    Task<Result<IEnumerable<GetUsersResponse>>> GetUsers(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string email = "",
        string role = "",
        bool status = true
    );

    Task<Result<GetUsersResponse>> GetUserById(Guid userId);
}
