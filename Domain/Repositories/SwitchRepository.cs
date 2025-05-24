using Domain.Databases;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Responses.Switches;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class SwitchRepository(AppDbContext context) : ISwitchRepository
{
    public async Task<IEnumerable<GetSwitchesResponse>> GetSwitches(
        int pageNumber = 1,
        int pageSize = 10,
        string search = "",
        string category = "",
        bool status = true
    )
    {
        IQueryable<Switch> query = context
            .Switches.AsNoTracking()
            .Include(k => k.Category)
            .Where(k => k.Status == status);
        if (search != "")
        {
            query = query.Where(k => EF.Functions.ILike(k.Name, $"%{search}%"));
        }
        if (category != "")
        {
            // query = query.Where(k => k.Category.Name == category);
            query = query.Where(k =>
                k.Category != null && EF.Functions.ILike(k.Category.Name, $"%{category}%")
            );
        }

        IEnumerable<GetSwitchesResponse> switches = await query
            .AsNoTracking()
            .OrderByDescending(k => k.CreatedAt)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Select(k => GetSwitchesResponse.FromEntity(k))
            .ToListAsync();
        return switches;
    }

    public async Task<GetSwitchesResponse?> GetSwitchById(Guid switchId)
    {
        var switchEntity = await context
            .Switches.AsNoTracking()
            .Include(k => k.Category)
            .FirstOrDefaultAsync(k => k.Id == switchId);

        return switchEntity is null ? null : GetSwitchesResponse.FromEntity(switchEntity);
    }
}
