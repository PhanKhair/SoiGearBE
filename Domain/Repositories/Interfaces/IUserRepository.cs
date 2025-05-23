using Domain.Responses.Users;

namespace Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<GetUsersResponse>> GetUsers(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string email = "",
        string role = "",
        bool status = true
    );

    Task<GetUsersResponse?> GetUserById(Guid userId);
}
