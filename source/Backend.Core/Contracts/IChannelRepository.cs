using Backend.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Entities;

namespace Backend.Core.Contracts
{
    public interface IChannelRepository
    {
        public Task AddAsync(Channel channel);
        public Task<Channel?> GetAsync(int id);
        public Task<List<Channel>> GetAsync();
        public Task DeleteAsync(int id);
    }
}
