﻿using Backend.Core.DTOs;
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
        public Task<long> Add(CreateMessageDTO createMessageDTO, int userId, int conversationId);
        public Task<MessageDTO> Get(int conversationId, int messageId);
        public Task<List<MessageDTO>> Get(int conversationId);
        public Task<bool> Delete(int userId, int conversationId, int messageId);
        public Task<bool> Update(UpdateMessageDTO updateMessageDTO, int userId, int conversationId, int messageId);
        public Task<int> GetAuthor(int id);

    }
}
