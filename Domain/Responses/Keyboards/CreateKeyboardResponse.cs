using Domain.Entities;

namespace Domain.Responses.Keyboards;

public record CreateKeyboardResponse(Guid Id)
{
    public static CreateKeyboardResponse FromEntity(Keyboard keyboard)
    {
        return new(keyboard.Id);
    }
};
