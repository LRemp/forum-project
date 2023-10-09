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
    public class ConversationMappingProfile: Profile
    {
        public ConversationMappingProfile() 
        {
            CreateMap<Conversation, UpdateConversationDTO>().ReverseMap();
            CreateMap<Conversation, CreateConversationDTO>().ReverseMap();
            CreateMap<Conversation, ConversationDTO>().ReverseMap();
        }
    }
}
