using Domain.Entities;
using Domain.Enums;

namespace Domain.Responses.Users;

public class GetUsersResponse
{
    public Guid Id { get; set; }
    public string Role { get; set; } = "";
    public string Name { get; set; } = "";
    public Gender? Gender { get; set; }
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Avatar { get; set; } = "";
    public bool Status { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public static GetUsersResponse FromEntity(User user)
    {
        return new()
        {
            Id = user.Id,
            Role = user.Role?.Name ?? "",
            Name = user.Name,
            Gender = user.Gender,
            Email = user.Email,
            Phone = user.Phone,
            Avatar = user.Avatar,
            Status = user.Status,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
        };
    }
}
