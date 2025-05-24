using Ardalis.Result;
using Domain.Repositories.Interfaces;
using Domain.Responses.Switches;

namespace Service.Switches;

public class SwitchService(ISwitchRepository switchRepository) : ISwitchService
{
    public async Task<Result<IEnumerable<GetSwitchesResponse>>> GetSwitches(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    )
    {
        IEnumerable<GetSwitchesResponse> switches = await switchRepository.GetSwitches(
            pageNumber,
            pageSize,
            search,
            category,
            status
        );

        if (!switches.Any())
        {
            return Result.Error("Không tìm thấy công tác");
        }
        return Result.Success(value: switches, "Lấy danh sách công tác thành công");
    }

    public async Task<Result<GetSwitchesResponse>> GetSwitchById(Guid switchId)
    {
        var sw = await switchRepository.GetSwitchById(switchId);

        if (sw is null)
        {
            return Result.NotFound("Không tìm thấy công tác");
        }

        return Result.Success(sw, "Lấy dữ liệu công tác thành công");
    }
}
