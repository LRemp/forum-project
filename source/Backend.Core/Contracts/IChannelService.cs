using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IChannelService
    {
        public Task Add(ChannelDTO channelDTO);
        public Task<Channel> Get(int id);
        public Task<List<Channel> Get();
        
    }
}
