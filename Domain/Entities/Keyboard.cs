using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shares;

namespace Domain.Entities;

public class Keyboard : BaseEntity
{
    public required Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string[] Images { get; set; } = [];
    public bool Status { get; set; } = false;

    // Navigational
    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }
}
