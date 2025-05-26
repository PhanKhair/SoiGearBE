using Ardalis.Result;
using Domain.Repositories.Interfaces;
using Domain.Responses.Switches;

namespace Service.Switches;

public class SwitchService(IUnitOfWork uow) : ISwitchService
{
    public async Task<Result<IEnumerable<GetSwitchesResponse>>> GetSwitches(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    )
    {
        IEnumerable<GetSwitchesResponse> switches = await uow.SwitchRepository.GetSwitches(
            pageNumber,
            pageSize,
            search,
            category,
            status
        );

        if (!switches.Any())
        {
            return Result.Error("Không tìm thấy công tắc");
        }
        return Result.Success(value: switches, "Lấy danh sách công tắc thành công");
    }

    public async Task<Result<GetSwitchesResponse>> GetSwitchById(Guid switchId)
    {
        var sw = await uow.SwitchRepository.GetSwitchById(switchId);

        if (sw is null)
        {
            return Result.NotFound("Không tìm thấy công tắc");
        }

        return Result.Success(sw, "Lấy dữ liệu công tắc thành công");
    }
}
