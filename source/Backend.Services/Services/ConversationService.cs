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
        public async Task Add(CreateConversationDTO createConversationDTO, int id)
        {
            var conversation = _mapper.Map<Conversation>(createConversationDTO);
            await _conversationRepository.AddAsync(conversation);
        }

        public async Task Delete(int id)
        {
            await _conversationRepository.DeleteAsync(id);
        }

        public async Task<ConversationDTO> Get(int id)
        {
            var conversation = await _conversationRepository.GetAsync(id);
            var conversationDTO = _mapper.Map<ConversationDTO>(conversation);
            return conversationDTO;
        }

        public async Task<List<ConversationDTO>> Get()
        {
            var conversations = await _conversationRepository.GetAsync();
            var conversationsDTO = _mapper.Map<List<ConversationDTO>>(conversations);
            return conversationsDTO;
        }

        public async Task Update(CreateConversationDTO createConversationDTO, int id)
        {
            var conversation = _mapper.Map<Conversation>(createConversationDTO);
            await _conversationRepository.UpdateAsync(conversation);
        }
    }
}
