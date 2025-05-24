using Domain.Responses.Categories;

namespace Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<GetCategoriesResponse>> GetCategories(
        int pageNumber = 1,
        int pageSize = 10,
        string search = ""
    );
    Task<GetCategoriesResponse?> GetCategoryById(Guid categoryId);
}
