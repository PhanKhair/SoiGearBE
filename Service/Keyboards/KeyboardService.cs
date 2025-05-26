using Ardalis.Result;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Responses.Categories;
using Domain.Responses.Keyboards;

namespace Service.Keyboards;

public class KeyboardService(IUnitOfWork uow) : IKeyboardService
{
    public async Task<Result<IEnumerable<GetKeyboardsResponse>>> GetKeyboards(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    )
    {
        IEnumerable<GetKeyboardsResponse> keyboards = await uow.KeyboardRepository.GetKeyboards(
            pageNumber,
            pageSize,
            search,
            category,
            status
        );

        if (!keyboards.Any())
        {
            return Result.Error("Không tìm thấy bàn phím");
        }
        return Result.Success(value: keyboards, "Lấy danh sách bàn phím thành công");
    }

    public async Task<Result<GetKeyboardsResponse>> GetKeyboardById(Guid keyboardId)
    {
        var keyboard = await uow.KeyboardRepository.GetKeyboardById(keyboardId);

        if (keyboard is null)
        {
            return Result.NotFound("Không tìm thấy bàn phím");
        }

        return Result.Success(keyboard, "Lấy dữ liệu bàn phím thành công");
    }

    public async Task<Result<CreateKeyboardResponse>> AddKeyboard(
        Guid categoryId,
        string name,
        string description,
        decimal price,
        string[] images,
        decimal? discount = 0
    )
    {
        GetCategoriesResponse? checking = await uow.CategoryRepository.GetCategoryById(categoryId);
        if (checking is null)
        {
            return Result.Error("Danh mục không tồn tại");
        }

        Keyboard newKeyboard = new()
        {
            CategoryId = categoryId,
            Name = name,
            Description = description,
            Price = price,
            Images = images,
            Discount = discount ?? 0,
        };

        await uow.KeyboardRepository.Add(newKeyboard);
        await uow.SaveChangesAsync(default);
        return Result.Success(
            CreateKeyboardResponse.FromEntity(newKeyboard),
            "Tạo bàn phím thành công"
        );
    }

    public async Task<Result<CreateKeyboardResponse>> UpdateKeyboard(
        Guid id,
        Guid categoryId,
        string name,
        string description,
        decimal price,
        string[] images,
        decimal? discount = 0
    )
    {
        GetCategoriesResponse? checking = await uow.CategoryRepository.GetCategoryById(categoryId);
        if (checking is null)
        {
            return Result.Error("Danh mục không tồn tại");
        }

        Keyboard? updated = await uow.KeyboardRepository.GetRawKeyboardById(id);
        if (updated is null)
        {
            return Result.Error("Bàn phím không tồn tại");
        }

        updated.Name = name;
        updated.Description = name;
        updated.Price = price;
        updated.Images = images;
        updated.Discount = discount ?? 0;

        await uow.SaveChangesAsync(default);
        return Result.SuccessWithMessage("Cập nhật bàn phím thành công");
    }

    public async Task<Result> DeleteKeyboard(Guid keyboardId)
    {
        var isRemoved = await uow.KeyboardRepository.Remove(keyboardId);

        if (!isRemoved)
        {
            return Result.NotFound("Không tìm thấy bàn phím");
        }

        await uow.SaveChangesAsync(default);
        return Result.SuccessWithMessage("Xoá bàn phím thành công");
    }
}
