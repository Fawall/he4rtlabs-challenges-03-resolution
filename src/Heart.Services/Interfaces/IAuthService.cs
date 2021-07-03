using System.Threading.Tasks;
using Heart.Services.DTO;

namespace Heart.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<bool> Login(UserDTO userDTO);
    }
}