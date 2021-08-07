using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heart.Infra.Interfaces
{
    public interface IRedisRepository
    {
        Task<List<string>> GetValuesFromRedis();   
    }
}