using Ardalis.Result;
using Domain.Repositories.Interfaces;
using Domain.Responses.Users;

namespace Service.Users;

public class UserService(IUnitOfWork uow) : IUserService
{
    public async Task<Result<IEnumerable<GetUsersResponse>>> GetUsers(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string email = "",
        string role = "",
        bool status = true
    )
    {
        IEnumerable<GetUsersResponse> users = await uow.UserRepository.GetUsers(
            pageNumber,
            pageSize,
            search,
            email,
            role,
            status
        );

        if (!users.Any())
        {
            return Result.Error("Không tìm thấy người dùng");
        }
        return Result.Success(value: users, "Lấy danh sách người dùng thành công");
    }

    public async Task<Result<GetUsersResponse>> GetUserById(Guid userId)
    {
        // Gọi repository bất đồng bộ
        var user = await uow.UserRepository.GetUserById(userId);

        if (user is null)
        {
            // Trả về 404 nếu không tìm thấy
            return Result.NotFound("Không tìm thấy người dùng");
        }

        // Trả về 200 kèm DTO
        return Result.Success(user, "Lấy dữ liệu người dùng thành công");
    }
}
