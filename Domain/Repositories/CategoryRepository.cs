using Domain.Databases;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Responses.Categories;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<GetCategoriesResponse>> GetCategories(
        int pageNumber = 1,
        int pageSize = 10,
        string search = ""
    )
    {
        IQueryable<Category> query = context.Categories.AsNoTracking();
        if (search != "")
        {
            query = query.Where(c => EF.Functions.ILike(c.Name, $"%{search}%"));
        }

        IEnumerable<GetCategoriesResponse> keyboards = await query
            .AsNoTracking()
            .OrderByDescending(c => c.CreatedAt)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Select(c => GetCategoriesResponse.FromEntity(c))
            .ToListAsync();
        return keyboards;
    }

    public async Task<GetCategoriesResponse?> GetCategoryById(Guid categoryId)
    {
        // await để lấy về User? thay vì Task<User?>
        var categoryEntity = await context
            .Categories.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        // giờ categoryEntity là User? nên có thể kiểm tra null và map sang DTO
        return categoryEntity is null ? null : GetCategoriesResponse.FromEntity(categoryEntity);
    }
}
