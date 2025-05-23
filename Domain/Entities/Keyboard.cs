using Domain.Shares;

namespace Domain.Entities;

public class Keyboard : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }
    public string[] Images { get; set; } = [];

    // Navigational
    public ICollection<UserKeyboard> UserKeyboards { get; set; } = [];
}
