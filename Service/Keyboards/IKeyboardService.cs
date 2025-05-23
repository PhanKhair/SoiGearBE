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
}
