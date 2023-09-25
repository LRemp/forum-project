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
        public Task AddAsync(Message message);
        public Task<Message?> GetAsync(int id);
        public Task<List<Message>> GetAsync();
        public Task DeleteAsync(int id);
        public Task UpdateAsync(UpdateMessageDTO updateMessageDTO);
    }
}
