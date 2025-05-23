using Domain.Databases;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Responses.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<IEnumerable<GetUsersResponse>> GetUsers(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string email = "",
        string role = "",
        bool status = true
    )
    {
        IQueryable<User> query = context
            .Users.AsNoTracking()
            .Include(u => u.Role)
            .Where(u => u.Status == status);
        if (search != "")
        {
            query = query.Where(u => EF.Functions.ILike(u.Name, $"%{search}%"));
        }
        if (email != "")
        {
            query = query.Where(u => EF.Functions.ILike(u.Email, $"%{email}%"));
        }
        if (role != "")
        {
            // query = query.Where(u => u.Role.Name == role);
            query = query.Where(u =>
                u.Role != null && EF.Functions.ILike(u.Role.Name, $"%{role}%")
            );
        }

        IEnumerable<GetUsersResponse> users = await query
            .AsNoTracking()
            .OrderByDescending(u => u.CreatedAt)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Select(u => GetUsersResponse.FromEntity(u))
            .ToListAsync();
        return users;
    }

    public async Task<GetUsersResponse?> GetUserById(Guid userId)
    {
        // await để lấy về User? thay vì Task<User?>
        var userEntity = await context
            .Users.AsNoTracking()
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == userId);

        // giờ userEntity là User? nên có thể kiểm tra null và map sang DTO
        return userEntity is null ? null : GetUsersResponse.FromEntity(userEntity);
    }
}
