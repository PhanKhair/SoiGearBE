using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Shares;

namespace Domain.Entities;

public class Switch : BaseEntity
{
    public required Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required SwitchType SwitchType { get; set; }
    public required float PreTravel { get; set; }
    public required float TotalTravel { get; set; }
    public required float BottomOut { get; set; }
    public required decimal MountingPin { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }
    public string[] Images { get; set; } = [];
    public bool Status { get; set; } = false;

    // Navigational
    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }
}
