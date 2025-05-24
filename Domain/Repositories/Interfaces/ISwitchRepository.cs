using Domain.Responses.Switches;

namespace Domain.Repositories.Interfaces;

public interface ISwitchRepository
{
    Task<IEnumerable<GetSwitchesResponse>> GetSwitches(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    );
    Task<GetSwitchesResponse?> GetSwitchById(Guid switchId);
}
