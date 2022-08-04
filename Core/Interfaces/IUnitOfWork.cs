using Core.Entities.UserEntity;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
