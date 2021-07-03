using Heart.Infra.Interfaces;
using Heart.Services.DTO;
using Heart.Services.Interfaces;
using System.Threading.Tasks;

namespace Heart.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        public async Task<bool> Login(UserDTO userDTO)
        {
            var userAuthentication = await _authRepository.Login(userDTO.Email, userDTO.Password);

            if(userAuthentication == true)
                return true;
                     
            return false;
        }
    }
}