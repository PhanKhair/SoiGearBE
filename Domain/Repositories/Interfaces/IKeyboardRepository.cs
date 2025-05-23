using Domain.Responses.Keyboards;

namespace Domain.Repositories.Interfaces;

public interface IKeyboardRepository
{
    Task<IEnumerable<GetKeyboardsResponse>> GetKeyboards(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    );
    Task<GetKeyboardsResponse?> GetKeyboardById(Guid keyboardId);
}
