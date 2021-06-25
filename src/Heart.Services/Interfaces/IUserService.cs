using System.Threading.Tasks;
using Heart.Services.DTO;

namespace Heart.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
    }
}