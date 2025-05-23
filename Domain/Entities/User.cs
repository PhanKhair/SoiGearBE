using Domain.Enums;

namespace Domain.Entities;

public class User
{
    // public string Name { get; set; } = "";
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Guid RoleId { get; set; }
    public required string Name { get; set; }
    public Gender? Gender { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
