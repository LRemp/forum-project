using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IConversationService
    {
        public Task<long> Add(CreateConversationDTO createConversationDTO, int channelId);
        public Task<ConversationDTO?> Get(int channelId, int conversationId);
        public Task<List<ConversationDTO>> Get(int channelId);
        public Task<bool> Delete(int channelId, int conversationId);
        public Task<bool> Update(UpdateConversationDTO createConversationDTO, int channelId, int conversationId);
     }
}
