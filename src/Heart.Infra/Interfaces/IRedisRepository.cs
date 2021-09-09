using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Infra.DTO;

namespace Heart.Infra.Interfaces
{
    public interface IRedisRepository
    {
        Task<List<UserDataDTO>> GetValuesFromRedis();   
    }
}