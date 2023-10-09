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
    public class ConversationService : IConversationService
    {
        private readonly IMapper _mapper;
        private readonly IConversationRepository _conversationRepository;
        public ConversationService(IConversationRepository conversationRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }
        public async Task<long> Add(CreateConversationDTO createConversationDTO, int channelId)
        {
            var conversation = _mapper.Map<Conversation>(createConversationDTO);
            return await _conversationRepository.AddAsync(conversation, channelId);
        }

        public async Task<bool> Delete(int channelId, int conversationId)
        {
            return await _conversationRepository.DeleteAsync(channelId, conversationId);
        }

        public async Task<ConversationDTO?> Get(int channelId, int conversationId)
        {
            var conversation = await _conversationRepository.GetAsync(channelId, conversationId);
            var conversationDTO = _mapper.Map<ConversationDTO>(conversation);
            return conversationDTO;
        }

        public async Task<List<ConversationDTO>> Get(int channelId)
        {
            var conversations = await _conversationRepository.GetAsync(channelId);
            var conversationsDTO = _mapper.Map<List<ConversationDTO>>(conversations);
            return conversationsDTO;
        }

        public async Task<bool> Update(UpdateConversationDTO updateConversationId, int channelId, int conversationId)
        {
            var conversation = _mapper.Map<Conversation>(updateConversationId);
            return await _conversationRepository.UpdateAsync(conversation, channelId, conversationId);
        }
    }
}
