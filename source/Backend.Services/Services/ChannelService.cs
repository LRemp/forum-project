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

        public async Task<int> Add(CreateChannelDTO createChannelDTO, int userId)
        {
            var channel = _mapper.Map<Channel>(createChannelDTO);
            var result = await _channelRepository.AddAsync(channel, userId);
            return result;
        }

        public async Task<int> ApproveRequest(int requestId)
        {
            return await _channelRepository.ApproveRequestAsync(requestId);
        }

        public async Task<bool> Delete(int channelId)
        {
            return await _channelRepository.DeleteAsync(channelId);
        }

        public async Task<ChannelDTO?> Get(int channelId)
        {
            var result = await _channelRepository.GetAsync(channelId);
            return result != null ? _mapper.Map<ChannelDTO>(result) : null;
        }

        public async Task<List<ChannelDTO>> Get()
        {
            var result = await _channelRepository.GetAsync();
            var channels = _mapper.Map<List<ChannelDTO>>(result);
            return channels;
        }

        public async Task<List<ChannelRequestDTO>> GetRequests()
        {
            var result = await _channelRepository.GetRequests();
            return result;
        }

        public async Task<bool> Update(UpdateChannelDTO updateChannelDTO, int channelId)
        {
            var channel = _mapper.Map<Channel>(updateChannelDTO);
            channel.Id = channelId;
            var result = await _channelRepository.UpdateAsync(channel);
            return result;
        }
    }
}
