using Core.Entities.UserEntity;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // INITIAL DATABASE
        private ApplicationContext _context;
        // INITIAL REPOSITORIES
        private IRepository<User> _userRepository;
        public UnitOfWork(ApplicationContext context) { _context = context; } // CTOR
        // GET FOR REPOSITORY
        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<User>(_context);
                return _userRepository;
            }
        }
        // REALISE Save();
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
        // DISPOSING
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
