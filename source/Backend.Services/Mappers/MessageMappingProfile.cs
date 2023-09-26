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
    public class MessageMappingProfile: Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
        }
    }
}
