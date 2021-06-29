using Heart.Services.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using Heart.Infra.Interfaces;
using Heart.Services.DTO;
using Heart.Domain.Entities;
using System;

namespace Heart.Services.Services
{
    public class UserServices : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }
    }
}