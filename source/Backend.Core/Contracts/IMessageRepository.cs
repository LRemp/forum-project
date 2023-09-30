using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IMessageRepository
    {
        public Task<long> AddAsync(Message message);
        public Task<Message?> GetAsync(int id);
        public Task<List<Message>> GetAsync();
        public Task<List<Message>> GetFilteredAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Message message);
    }
}
