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
        public async Task<long> AddAsync(Message message)
        {
            var query = @"INSERT INTO messages(text, author, channel, edited)
                            VALUES(@text, @author, @channel, @edited);
                            SELECT LAST_INSERTED_ID()";

            var rowId = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                text = message.Text,
                author = message.Author,
                channel = message.Channel,
                edited = message.Edited
            });
            return rowId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"DELETE FROM messages WHERE id = @id";
            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new { id });
            return affectedRows > 0;
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

        public async Task<List<Message>> GetFilteredAsync(int id)
        {
            var query = @"SELECT * FROM messages
                            WHERE conversation = @id";
            var list = await _mysqlConnection.QueryAsync<Message>(query, new { id });
            return list.ToList();
        }

        public async Task<bool> UpdateAsync(Message message)
        {
            var query = @"UPDATE messages
                            SET text = @text
                            WHERE id = @id";

            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new
            {
                id = message.Id,
                text = message.Text
            });
            return affectedRows > 0;
        }
    }
}
