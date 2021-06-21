using System.Threading.Tasks;
using System.Collections.Generic;
using Heart.Domain.Entities;

namespace Heart.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        
    }
}