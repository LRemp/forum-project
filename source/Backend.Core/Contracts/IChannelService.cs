using Backend.Core.DTOs;

namespace Backend.Core.Contracts
{
    public interface IChannelService
    {
        public Task Add(ChannelDTO channelDTO);
        public Task<ChannelDTO> Get(int id);
        public Task<List<ChannelDTO>> Get();
        public Task Delete(int id);
        public Task Update(ChannelDTO channelDTO);
    }
}
