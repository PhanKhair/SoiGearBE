using Ardalis.Result;
using Domain.Repositories.Interfaces;
using Domain.Responses.Keyboards;

namespace Service.Keyboards;

public class KeyboardService(IKeyboardRepository keyboardRepository) : IKeyboardService
{
    public async Task<Result<IEnumerable<GetKeyboardsResponse>>> GetKeyboards(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    )
    {
        IEnumerable<GetKeyboardsResponse> keyboards = await keyboardRepository.GetKeyboards(
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
        var keyboard = await keyboardRepository.GetKeyboardById(keyboardId);

        if (keyboard is null)
        {
            return Result.NotFound("Không tìm thấy bàn phím");
        }

        return Result.Success(keyboard, "Lấy dữ liệu bàn phím thành công");
    }
}
