using AutoMapper;
using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private User user = new User
        {
            Id = 1,
            Username = "system",
            Password = "password",
            Email = "system@forum.com",
            Avatar = "image.url"
        };
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<long> Add(CreateMessageDTO createMessageDTO, string username, int conversationId)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            return await _messageRepository.AddAsync(user, message, conversationId);
        }

        public async Task<bool> Delete(string username, int conversationId, int messageId)
        {
            return await _messageRepository.DeleteAsync(user, conversationId, messageId);
        }

        public async Task<MessageDTO> Get(int conversationId, int messageId)
        {
            var message = await _messageRepository.GetAsync(conversationId, messageId);
            var messageDTO = _mapper.Map<MessageDTO>(message);
            return messageDTO;
        }

        public async Task<List<MessageDTO>> Get(int conversationId)
        {
            var messages = await _messageRepository.GetAsync(conversationId);
            var messagesDTO = _mapper.Map<List<MessageDTO>>(messages);
            return messagesDTO;
        }

        public async Task<bool> Update(UpdateMessageDTO updateMessageDTO, string username, int conversationId, int messageId)
        {
            var message = _mapper.Map<Message>(updateMessageDTO);
            message.Id = messageId;
            message.FkConversation = conversationId;
            return await _messageRepository.UpdateAsync(user, message, conversationId, messageId);
        }
    }
}
