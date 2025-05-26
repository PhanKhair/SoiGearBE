using Ardalis.Result;
using Domain.Repositories.Interfaces;
using Domain.Responses.Categories;

namespace Service.Categories;

public class CategoryService(IUnitOfWork uow) : ICategoryService
{
    public async Task<Result<IEnumerable<GetCategoriesResponse>>> GetCategories(
        int pageNumber = 1,
        int pageSize = 10,
        string search = ""
    )
    {
        IEnumerable<GetCategoriesResponse> keyboards = await uow.CategoryRepository.GetCategories(
            pageNumber,
            pageSize,
            search
        );

        if (!keyboards.Any())
        {
            return Result.Error("Không tìm thấy danh mục");
        }
        return Result.Success(value: keyboards, "Lấy danh sách danh mục thành công");
    }

    public async Task<Result<GetCategoriesResponse>> GetCategoryById(Guid categoryId)
    {
        var category = await uow.CategoryRepository.GetCategoryById(categoryId);

        if (category is null)
        {
            return Result.NotFound("Không tìm thấy danh mục");
        }

        return Result.Success(category, "Lấy dữ liệu danh mục thành công");
    }
}
