using Heart.Services.Interfaces;
using System.Threading.Tasks;
using Heart.Infra.Interfaces;
using Heart.Services.DTO;
using Heart.Domain.Entities;
using System;
using Heart.Core.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Heart.Services.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRedisRepository _redisRepository;
        public UserServices(IUserRepository userRepository, IRedisRepository redisRepository)
        {
            _userRepository = userRepository;
            _redisRepository = redisRepository;
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
            var allUsers = await _redisRepository.GetValuesFromRedis();
    
            return allUsers;
        }
    }
}