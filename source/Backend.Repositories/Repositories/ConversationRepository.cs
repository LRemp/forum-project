using Backend.Core.Contracts;
using Backend.Core.DTOs;
using Backend.Core.Entities;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly MySqlConnection _mysqlConnection;
        public ConversationRepository(MySqlConnection mysqlConnection)
        {
            _mysqlConnection = mysqlConnection;
            _mysqlConnection.Open();
        }
        public async Task<long> AddAsync(Conversation conversation, int channelId)
        {
            var query = @"INSERT INTO conversations(name, description, fk_author, fk_channel)
                            VALUES(@name, @description, @author, @channel);
                            SELECT LAST_INSERT_ID()";
            
            var rowId = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                name = conversation.Name,
                description = conversation.Description,
                author = conversation.FkAuthor,
                channel = channelId
            });
            return rowId;
        }

        public async Task<bool> DeleteAsync(int channelId, int conversationId)
        {
            var query = @"DELETE FROM conversations WHERE id = @id AND fk_channel = @channel";
            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new { 
                id = conversationId, channel = channelId
            });
            return affectedRows > 0;
        }

        public async Task<Conversation?> GetAsync(int channelId, int conversationId)
        {
            var query = @"SELECT * 
                            FROM conversations c
                            JOIN channels ch ON c.fk_channel = ch.id 
                            WHERE c.id = @id AND c.fk_channel = @channel";
            var result = await _mysqlConnection.QueryAsync<Conversation, Channel, Conversation>(query, (conversation, channel) => {
                conversation.Channel = channel;
                return conversation;
            }, new { 
                id = conversationId,
                channel = channelId
            });
            return result.FirstOrDefault();
        }

        public async Task<List<Conversation>> GetAsync(int channelId)
        {
            var query = @"SELECT * 
                            FROM conversations c
                            JOIN channels ch ON c.fk_channel = ch.id 
                            WHERE c.fk_channel = @channel";
            var result = await _mysqlConnection.QueryAsync<Conversation, Channel, Conversation>(query, (conversation, channel) => {
                conversation.Channel = channel;
                return conversation;
            }, new { channel = channelId });
            return result.ToList();
        }

        public async Task<bool> UpdateAsync(Conversation conversation, int channelId, int conversationId)
        {
            var query = @"UPDATE conversations
                            SET description = @description
                            WHERE id = @id AND fk_channel = @channel";

            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new
            {
                id = conversationId,
                name = conversation.Name,
                description = conversation.Description,
                channel = channelId
            });
            return affectedRows > 0;
        }
    }
}
