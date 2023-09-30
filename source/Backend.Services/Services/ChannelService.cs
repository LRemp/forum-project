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
        public ChannelService(IMapper mapper, IChannelRepository channelRepository)
        {
            _mapper = mapper;
            _channelRepository = channelRepository;
        }

        public async Task<ChannelDTO?> Add(ChannelDTO channelDTO)
        {
            var channel = _mapper.Map<Channel>(channelDTO);
            var result = await _channelRepository.AddAsync(channel);
            return result != null ? _mapper.Map<ChannelDTO>(result) : null;
        }

        public async Task<bool> Delete(int id)
        {
            return await _channelRepository.DeleteAsync(id);
        }

        public async Task<ChannelDTO?> Get(int id)
        {
            var result = await _channelRepository.GetAsync(id);
            return result != null ? _mapper.Map<ChannelDTO>(result) : null;
        }

        public async Task<List<ChannelDTO>> Get()
        {
            var result = await _channelRepository.GetAsync();
            var channels = _mapper.Map<List<ChannelDTO>>(result);
            return channels;
        }

        public async Task<bool> Update(ChannelDTO channelDTO, int id)
        {
            var channel = _mapper.Map<Channel>(channelDTO);
            channel.Id = id;
            var result = await _channelRepository.UpdateAsync(channel);
            return result;
        }
    }
}
