using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IMessageService
    {
        public Task<long> Add(CreateMessageDTO createMessageDTO, User user, int channelId, int conversationId);
        public Task<Message> Get(int channelId, int conversationId, int messageId);
        public Task<List<Message>> Get(int channeldId, int conversationId);
        public Task<bool> Delete(int channelId, int conversationId, int messageId);
        public Task<bool> Update(CreateMessageDTO createMessageDTO, User user, int channelId, int conversationId);

    }
}
