using Ardalis.Result;
using Domain.Responses.Keyboards;

namespace Service.Keyboards;

public interface IKeyboardService
{
    Task<Result<IEnumerable<GetKeyboardsResponse>>> GetKeyboards(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    );

    Task<Result<GetKeyboardsResponse>> GetKeyboardById(Guid keyboardId);
    Task<Result<CreateKeyboardResponse>> AddKeyboard(
        Guid categoryId,
        string name,
        string description,
        decimal price,
        string[] images,
        decimal? discount = 0
    );

    Task<Result<CreateKeyboardResponse>> UpdateKeyboard(
        Guid id,
        Guid categoryId,
        string name,
        string description,
        decimal price,
        string[] images,
        decimal? discount = 0
    );

    Task<Result> DeleteKeyboard(Guid keyboardId);
}
