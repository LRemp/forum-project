using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IConversationRepository
    {
        public Task<long> AddAsync(Conversation conversation, int channelId);
        public Task<Conversation?> GetAsync(int channelId, int conversationId);
        public Task<List<Conversation>> GetAsync(int channelId);
        public Task<bool> DeleteAsync(int channelId, int conversationId);
        public Task<bool> UpdateAsync(Conversation conversation, int channelId, int conversationId);
    }
}
