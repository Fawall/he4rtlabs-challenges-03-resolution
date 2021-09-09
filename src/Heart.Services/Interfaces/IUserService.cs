using System.Collections.Generic;
using System.Threading.Tasks;
using Heart.Infra.DTO;
using Heart.Services.DTO;

namespace Heart.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<List<UserDataDTO>> GetAll();
    }
}