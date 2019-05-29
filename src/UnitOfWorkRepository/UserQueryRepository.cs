using Model;
using System.Collections.Generic;
using UnitOfWorkPersistence;
using UnitOfWorkRepository.Models;
using UnitOfWorkRepository.Projections;
using UnitOfWorkRepository.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UnitOfWorkRepository
{
    /*
     * Add the interfaces according the behavior that you want to give to your repository.
     * For example, if you only want to Create and Read, remove the other interfaces.
     */
    public interface IUserQueryRepository : IPagedRepository<UserExample>, IReadRepository<UserExample>
    {
        IEnumerable<UserReportAggregate> GetReportUserSample();
    }

    public class UserQueryRepository : GenericRepository<UserExample>, IUserQueryRepository
    {
        public UserQueryRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public IEnumerable<UserReportAggregate> GetReportUserSample()
        {
            //Suppose this is a complex query
            return _context.Users.Select(x => new UserReportAggregate()
            {
                Name = x.Name,
                LastName = x.LastName
            }).AsNoTracking()
            .ToList();
        }

    }
}
