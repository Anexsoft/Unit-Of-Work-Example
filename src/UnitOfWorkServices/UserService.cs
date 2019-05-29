using Model;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;
using UnitOfWorkRepository;
using UnitOfWorkRepository.Projections;
using UnitOfWorkRepository.Repository;

namespace UnitOfWorkServices
{
    public interface IUserService
    {
        IEnumerable<UserExample> GetAll();
        void Create(UserExample model);
        DataCollection<UserExample> Paged(int page, int take);
        IEnumerable<UserReportAggregate> GetReportUserSample();
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserQueryRepository _userQueryRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserQueryRepository userQueryRepository
        )
        {
            _uow = unitOfWork;
            _userQueryRepository = userQueryRepository;
        }

        public void Create(UserExample model)
        {
            // Call to your repository
            _uow.Repository.UserRepository.Add(model);

            // Save changes
            _uow.SaveChanges();
        }

        public IEnumerable<UserExample> GetAll()
        {
            return _uow.Repository.UserRepository.GetAll();
        }

        public DataCollection<UserExample> Paged(int page, int take)
        {
            return _uow.Repository.UserRepository.GetPaged(
                page: page,
                take: take,
                orderBy: x => x.OrderByDescending(y => y.Id)
            );
        }

        public IEnumerable<UserReportAggregate> GetReportUserSample()
        {
            return _userQueryRepository.GetReportUserSample();
        }

    }
}
