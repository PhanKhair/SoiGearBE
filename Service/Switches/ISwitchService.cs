using Ardalis.Result;
using Domain.Responses.Switches;

namespace Service.Switches;

public interface ISwitchService
{
    Task<Result<IEnumerable<GetSwitchesResponse>>> GetSwitches(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    );
    Task<Result<GetSwitchesResponse>> GetSwitchById(Guid switchId);
}
