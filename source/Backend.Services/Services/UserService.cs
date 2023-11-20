﻿using AutoMapper;
using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository) 
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<bool> CheckPasswordAsync(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDTO.Username);


            return BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password);
        }
        public async Task<UserDTO> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<List<string>> GetUserRoles(int id)
        {
            List<string> roles = new List<string>
            {
                "User"
            };
            return roles;
        }
        public async Task<bool> UpdateAsync(UpdateUserDTO user)
        {
            var userEntity = await _userRepository.GetByUsernameAsync(user.Username);
            var result = await _userRepository.UpdateAsync(userEntity);
            return result;
        }
    }
}