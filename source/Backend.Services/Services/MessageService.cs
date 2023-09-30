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
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<long> Add(CreateMessageDTO createMessageDTO, User user)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            message.Author = user.Id;
            return await _messageRepository.AddAsync(message);
        }

        public async Task<bool> Delete(int id)
        {
            return await _messageRepository.DeleteAsync(id);
        }

        public async Task<Message> Get(int id)
        {
            var message = await _messageRepository.GetAsync(id);
            return message;
        }

        public async Task<List<Message>> GetAll()
        {
            var messages = await _messageRepository.GetAsync();
            return messages;
        }

        public async Task<List<Message>> GetConversationMessages(int conversation)
        {
            var messages = await _messageRepository.GetFilteredAsync(conversation);
            return messages;
        }

        public async Task<bool> Update(CreateMessageDTO createMessageDTO, int id, User user)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            message.Id = id;
            return await _messageRepository.UpdateAsync(message);
        }
    }
}
