using Backend.Core.Contracts;
using Backend.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(_ => new MySqlConnection(configuration.GetConnectionString("mysql")));

            services.AddTransient<IChannelRepository, ChannelRepository>();
            services.AddTransient<IConversationRepository, ConversationRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
        }
    }
}
