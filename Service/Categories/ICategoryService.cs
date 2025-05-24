using Ardalis.Result;
using Domain.Responses.Categories;

namespace Service.Categories;

public interface ICategoryService
{
    Task<Result<IEnumerable<GetCategoriesResponse>>> GetCategories(
        int pageNumber = 1,
        int pageSize = 10,
        string search = ""
    );
    Task<Result<GetCategoriesResponse>> GetCategoryById(Guid categoryId);
}
