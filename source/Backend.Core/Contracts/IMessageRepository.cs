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
        public Task<long> AddAsync(Message message, int conversationId);
        public Task<Message?> GetAsync(int conversationId, int messageId);
        public Task<List<Message>> GetAsync(int conversationId);
        public Task<List<Message>> GetFilteredAsync(int id);
        public Task<bool> DeleteAsync(int userId, int conversationId, int messageId);
        public Task<bool> UpdateAsync(int userId, Message message, int conversationId, int messageId);
        public Task<int> GetAuthorAsync(int id);
    }
}
