using AutoMapper;
using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;

namespace Backend.Services.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IMapper _mapper;
        private readonly IChannelRepository _channelRepository;
        public async Task Add(ChannelDTO channelDTO)
        {
            var channel = _mapper.Map<Channel>(channelDTO);
            await _channelRepository.AddAsync(channel);
        }

        public async Task Delete(int id)
        {
            await _channelRepository.DeleteAsync(id);
        }

        public Task<ChannelDTO> Get(int id)
        {

            throw new NotImplementedException();
        }

        public Task<List<ChannelDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(ChannelDTO channelDTO)
        {
            throw new NotImplementedException();
        }
    }
}
