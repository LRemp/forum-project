﻿using Backend.Core.DTOs;
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
        public Task Add(CreateMessageDTO createMessageDTO);
        public Task<ConversationDTO> Get(int id);
        public Task<List<ConversationDTO>> Get();
        public Task Delete(int id);
        public Task Update(UpdateConversationDTO updateConversationDTO, int id);
     }
}
