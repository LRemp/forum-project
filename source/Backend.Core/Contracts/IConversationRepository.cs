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
        public Task AddAsync(Conversation conversation);
        public Task<Conversation?> GetAsync(int id);
        public Task<List<Conversation>> GetAsync();
        public Task DeleteAsync(int id);
        public Task UpdateAsync(UpdateConversationDTO updateConversationDTO);
    }
}
