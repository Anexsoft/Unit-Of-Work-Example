using Model;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;
using UnitOfWorkRepository.Repository;

namespace UnitOfWorkServices
{
    public interface IUserService
    {
        IEnumerable<UserExample> GetAll();
        void Create(UserExample model);
        DataCollection<UserExample> Paged(int page, int take);
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(
            IUnitOfWork unitOfWork
        )
        {
            _uow = unitOfWork;
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
    }
}
