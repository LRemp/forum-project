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
    public class MessageRepository : IMessageRepository
    {
        private readonly MySqlConnection _mysqlConnection;
        public MessageRepository(MySqlConnection mysqlConnection)
        {
            _mysqlConnection = mysqlConnection;
            _mysqlConnection.Open();
        }
        public async Task AddAsync(Message message)
        {
            var query = @"INSERT INTO messages(text, author, channel, edited)
                            VALUES(@text, @author, @channel, @edited)";

            await _mysqlConnection.QueryAsync(query, new
            {
                text = message.Text,
                author = message.Author,
                channel = message.Channel,
                edited = message.Edited
            });
        }

        public async Task DeleteAsync(int id)
        {
            var query = @"DELETE FROM messages WHERE id = @id";
            await _mysqlConnection.ExecuteAsync(query, new { id });
        }

        public async Task<Message?> GetAsync(int id)
        {
            var query = @"SELECT * FROM messages WHERE id = @id";
            var list = await _mysqlConnection.QueryAsync<Message>(query, new { id });
            return list.FirstOrDefault();
        }

        public async Task<List<Message>> GetAsync()
        {
            var query = @"SELECT * FROM messages";
            var list = await _mysqlConnection.QueryAsync<Message>(query);
            return list.ToList();
        }

        public async Task UpdateAsync(Message message)
        {
            var query = @"UPDATE messages
                            SET text = @text
                            WHERE id = @id";

            await _mysqlConnection.ExecuteAsync(query, new
            {
                id = message.Id,
                text = message.Text
            });
        }
    }
}
