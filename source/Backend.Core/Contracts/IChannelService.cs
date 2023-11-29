using Backend.Core.DTOs;

namespace Backend.Core.Contracts
{
    public interface IChannelService
    {
        public Task<int> Add(CreateChannelDTO createChannelDTO, int userId);
        public Task<ChannelDTO?> Get(int channelId);
        public Task<List<ChannelDTO>> Get();
        public Task<bool> Delete(int channelId);
        public Task<bool> Update(UpdateChannelDTO updateChannelDTO, int channelId);
        public Task<int> ApproveRequest(int requestId);
        public Task<List<ChannelRequestDTO>> GetRequests();
    }
}
