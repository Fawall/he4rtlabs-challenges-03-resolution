using Heart.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Heart.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Get(long id);
        Task<List<string>> GetAll();
    }
}