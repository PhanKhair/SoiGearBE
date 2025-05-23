using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shares;

namespace Domain.Entities;

public class UserKeyboard : BaseEntity
{
    public required Guid UserId { get; set; }
    public required Guid KeyboardId { get; set; }

    [ForeignKey(nameof(KeyboardId))]
    public Keyboard? Keyboard { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}
