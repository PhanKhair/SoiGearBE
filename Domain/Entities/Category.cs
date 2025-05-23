using Domain.Shares;

namespace Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public ICollection<Keyboard> Keyboards { get; set; } = [];
    public ICollection<Switch> Switches { get; set; } = [];
}
