using Domain.Databases;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private bool _disposed;
        private IUserRepository _userRepository = null!;
        private IKeyboardRepository _keyboardRepository = null!;
        private ISwitchRepository _switchRepository = null!;
        private ICategoryRepository _categoryRepository = null!;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository is null)
                {
                    _userRepository = new UserRepository(context);
                }
                return _userRepository;
            }
        }

        public IKeyboardRepository KeyboardRepository
        {
            get
            {
                if (_keyboardRepository is null)
                {
                    _keyboardRepository = new KeyboardRepository(context);
                }
                return _keyboardRepository;
            }
        }

        public ISwitchRepository SwitchRepository
        {
            get
            {
                if (_switchRepository is null)
                {
                    _switchRepository = new SwitchRepository(context);
                }
                return _switchRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository is null)
                {
                    _categoryRepository = new CategoryRepository(context);
                }
                return _categoryRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
            await context.SaveChangesAsync(cancellationToken);
    }
}
