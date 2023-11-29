using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IUserRepository
    {
        public Task<long> AddAsync(User user);
        public Task<User?> GetAsync(int id);
        public Task<User?> GetByUsernameAsync(string username);
        public Task<bool> UpdateAsync(User user);
        public Task<bool> IsAdminAsync(int id);
    }
}
