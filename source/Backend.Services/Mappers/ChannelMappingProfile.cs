using AutoMapper;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mappers
{
    public class ChannelMappingProfile: Profile
    {
        public ChannelMappingProfile() {

            CreateMap<Channel, CreateChannelDTO>().ReverseMap();
            CreateMap<Channel, UpdateChannelDTO>().ReverseMap();
            CreateMap<Channel, ChannelDTO>().ReverseMap();
        }
    }
}
