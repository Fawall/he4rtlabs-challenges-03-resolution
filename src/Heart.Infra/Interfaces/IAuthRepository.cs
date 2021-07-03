using System.Threading.Tasks;

namespace Heart.Infra.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> Login(string email, string password);
    }
}