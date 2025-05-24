using Domain.Databases;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Responses.Keyboards;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class KeyboardRepository(AppDbContext context) : IKeyboardRepository
{
    public async Task<IEnumerable<GetKeyboardsResponse>> GetKeyboards(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    )
    {
        IQueryable<Keyboard> query = context
            .Keyboards.AsNoTracking()
            .Include(k => k.Category)
            .Where(k => k.Status == status);
        if (search != "")
        {
            query = query.Where(k => EF.Functions.ILike(k.Name, $"%{search}%"));
        }
        if (category != "")
        {
            // query = query.Where(k => k.Category.Name == category);
            query = query.Where(k =>
                k.Category != null && EF.Functions.ILike(k.Category.Name, $"%{category}%")
            );
        }

        IEnumerable<GetKeyboardsResponse> keyboards = await query
            .AsNoTracking()
            .OrderByDescending(k => k.CreatedAt)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Select(k => GetKeyboardsResponse.FromEntity(k))
            .ToListAsync();
        return keyboards;
    }

    public async Task<GetKeyboardsResponse?> GetKeyboardById(Guid keyboardId)
    {
        // await để lấy về User? thay vì Task<User?>
        var keyboardEntity = await context
            .Keyboards.AsNoTracking()
            .Include(k => k.Category)
            .FirstOrDefaultAsync(k => k.Id == keyboardId);

        // giờ keyboardEntity là User? nên có thể kiểm tra null và map sang DTO
        return keyboardEntity is null ? null : GetKeyboardsResponse.FromEntity(keyboardEntity);
    }
}
