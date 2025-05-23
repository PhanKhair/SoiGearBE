using Domain.Entities;

namespace Domain.Responses.Keyboards;

public class GetKeyboardsResponse
{
    public Guid Id { get; set; }
    public string Category { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string[] Images { get; set; } = [];
    public bool Status { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public static GetKeyboardsResponse FromEntity(Keyboard keyboard)
    {
        return new()
        {
            Id = keyboard.Id,
            Category = keyboard.Category?.Name ?? "",
            Name = keyboard.Name,
            Description = keyboard.Description,
            Price = keyboard.Price,
            Discount = keyboard.Discount,
            Images = keyboard.Images,
            Status = keyboard.Status,
            CreatedAt = keyboard.CreatedAt,
            UpdatedAt = keyboard.UpdatedAt,
        };
    }
}
