using Heart.Services.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if(userExists != null)
                throw new DomainException("Já existe um usuário com este email");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<List<string>> GetAll()
        {
            var allUsers = await _userRepository.GetAll();

            return allUsers;
        }
    }
}