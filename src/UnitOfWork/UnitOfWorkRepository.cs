using UnitOfWorkPersistence;
using UnitOfWorkRepository;

namespace UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
    }

    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IUserRepository UserRepository { get; }

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            UserRepository = new UserRepository(context);
        }
    }
}
