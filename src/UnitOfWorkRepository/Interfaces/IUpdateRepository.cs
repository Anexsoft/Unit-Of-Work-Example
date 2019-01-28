using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitOfWorkRepository.Repository.Interfaces
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T t);
        void Update(IEnumerable<T> t);
    }
}
