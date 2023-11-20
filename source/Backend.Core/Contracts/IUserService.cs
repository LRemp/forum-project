using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IUserService
    {
        public Task<UserDTO> GetAsync(int id);
        public Task<bool> UpdateAsync(UpdateUserDTO user);
        public Task<bool> CheckPasswordAsync(LoginDTO loginDTO);
        public Task<List<string>> GetUserRoles(int id);
    }
}
