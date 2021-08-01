using Heart.Services.Interfaces;
using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using Heart.Services.DTO;
using Heart.Domain.Entities;
using System;
using Heart.Core.Exceptions;
using System.Collections.Generic;

namespace Heart.Services.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if(userExists != null)
                throw new DomainException("Já existe um usuário com este email");

            User user = new User(userDTO.Email, userDTO.Password);

            user.Validate();

            var userCreated = await _userRepository.Create(user);

            userDTO = new UserDTO(userCreated.Email, userCreated.Password);

            return userDTO;
        }

        public async Task<List<string>> GetAll()
        {
            var allUsers = await _userRepository.GetAll();

            return allUsers;
        }
    }
}