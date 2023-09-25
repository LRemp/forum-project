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
        public async Task AddAsync(Conversation conversation)
        {
            var query = @"INSERT INTO conversation(name, description, author, channel)
                            VALUES(@name, @description, @author, @channel)";
            
            await _mysqlConnection.QueryAsync(query, new
            {
                name = conversation.Name,
                description = conversation.Description,
                author = conversation.Author,
                channel = conversation.Channel
            });
        }

        public async Task DeleteAsync(int id)
        {
            var query = @"DELETE FROM conversations WHERE id = @id";
            await _mysqlConnection.ExecuteAsync(query, new { id });
        }

        public async Task<Conversation?> GetAsync(int id)
        {
            var query = @"SELECT * FROM conversations WHERE id = @id";
            var result = await _mysqlConnection.QueryAsync<Conversation>(query, new { id });
            return result.FirstOrDefault();
        }

        public async Task<List<Conversation>> GetAsync()
        {
            var query = @"SELECT * FROM conversations";
            var result = await _mysqlConnection.QueryAsync<Conversation>(query);
            return result.ToList();
        }

        public async Task UpdateAsync(UpdateConversationDTO updateConversationDTO)
        {
            var query = @"UPDATE conversations
                            SET name = @name, description = @description
                            WHERE id = @id";

            await _mysqlConnection.ExecuteAsync(query, new
            {
                id = updateConversationDTO.Id,
                name = updateConversationDTO.Name,
                description = updateConversationDTO.Description
            });
        }
    }
}
