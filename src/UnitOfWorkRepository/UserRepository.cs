using Model;
using UnitOfWorkPersistence;
using UnitOfWorkRepository.Models;
using UnitOfWorkRepository.Repository.Interfaces;

namespace UnitOfWorkRepository
{
    /*
     * Add the interfaces according the behavior that you want to give to your repository.
     * For example, if you only want to Create and Read, remove the other interfaces.
     */
    public interface IUserRepository : IPagedRepository<UserExample>, IReadRepository<UserExample>, ICreateRepository<UserExample>, IRemoveRepository<UserExample>, IUpdateRepository<UserExample>
    {

    }

    public class UserRepository : GenericRepository<UserExample>, IUserRepository
    {
        public UserRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
    }
}
