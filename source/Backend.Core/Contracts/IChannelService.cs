using Backend.Core.DTOs;

namespace Backend.Core.Contracts
{
    public interface IChannelService
    {
        public Task<long> Add(ChannelDTO channelDTO);
        public Task<ChannelDTO?> Get(int id);
        public Task<List<ChannelDTO>> Get();
        public Task<bool> Delete(int id);
        public Task<bool> Update(ChannelDTO channelDTO, int id);
    }
}
