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
        public Task<long> Add(CreateMessageDTO createMessageDTO, User user);
        public Task<Message> Get(int id);
        public Task<List<Message>> GetAll();
        public Task<List<Message>> GetConversationMessages(int conversation);
        public Task<bool> Delete(int id);
        public Task<bool> Update(CreateMessageDTO createMessageDTO, int id, User user);

    }
}
