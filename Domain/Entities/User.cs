using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Shares;

namespace Domain.Entities;

public class User : BaseEntity
{
    // Properties
    // public string Name { get; set; } = "";
    public required Guid RoleId { get; set; }
    public required string Name { get; set; }
    public Gender? Gender { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public bool Status { get; set; } = false;
    public string Avatar { get; set; } = "";

    // Navigational
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
}
