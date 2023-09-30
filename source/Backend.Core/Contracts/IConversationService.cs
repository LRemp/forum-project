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
        public Task<long> Add(CreateConversationDTO createConversationDTO, int id);
        public Task<ConversationDTO?> Get(int id);
        public Task<List<ConversationDTO>> Get();
        public Task<bool> Delete(int id);
        public Task<bool> Update(CreateConversationDTO createConversationDTO, int id);
     }
}
