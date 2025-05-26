namespace Domain.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IKeyboardRepository KeyboardRepository { get; }
    ISwitchRepository SwitchRepository { get; }
    ICategoryRepository CategoryRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
