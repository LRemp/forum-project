using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Services.Mappers;
using Backend.Core.Contracts;
using Backend.Services.Services;

namespace Backend.Services.Extensions
{
    public static class ServiceExtension
    {
        public static void AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MessageMappingProfile));
            services.AddAutoMapper(typeof(ConversationMappingProfile));
            services.AddAutoMapper(typeof(ChannelMappingProfile));

            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IConversationService, ConversationService>();
        }
    }
}
