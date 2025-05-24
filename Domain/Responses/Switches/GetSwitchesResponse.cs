using Domain.Entities;
using Domain.Enums;

namespace Domain.Responses.Switches;

public class GetSwitchesResponse
{
    public Guid Id { get; set; }
    public string Category { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public SwitchType SwitchType { get; set; }
    public required float PreTravel { get; set; }
    public required float TotalTravel { get; set; }
    public required float BottomOut { get; set; }
    public required decimal MountingPin { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string[] Images { get; set; } = [];
    public bool Status { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public static GetSwitchesResponse FromEntity(Switch sw)
    {
        return new()
        {
            Id = sw.Id,
            Category = sw.Category?.Name ?? "",
            Name = sw.Name,
            Description = sw.Description,
            SwitchType = sw.SwitchType,
            PreTravel = sw.PreTravel,
            TotalTravel = sw.TotalTravel,
            BottomOut = sw.BottomOut,
            MountingPin = sw.MountingPin,
            Price = sw.Price,
            Discount = sw.Discount,
            Images = sw.Images,
            Status = sw.Status,
            CreatedAt = sw.CreatedAt,
            UpdatedAt = sw.UpdatedAt,
        };
    }
}
