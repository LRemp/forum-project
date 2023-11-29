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
        public async Task<long> AddAsync(Message message, int conversationId)
        {
            var query = @"INSERT INTO messages(text, fk_author, fk_conversation, edited)
                            VALUES(@text, @author, @conversation, @edited);
                            SELECT LAST_INSERT_ID()";

            var rowId = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                text = message.Text,
                author = message.FkAuthor,
                conversation = conversationId,
                edited = message.Edited
            });
            return rowId;
        }

        public async Task<bool> DeleteAsync(int userId, int conversationId, int messageId)
        {
            var query = @"DELETE FROM messages WHERE id = @id AND fk_conversation = @conversation";
            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new { 
                id = messageId,
                author = userId,
                conversation = conversationId
            });
            return affectedRows > 0;
        }

        public async Task<Message?> GetAsync(int conversationId, int messageId)
        {
            var query = @"SELECT * 
                            FROM messages m
                            JOIN conversations c ON m.fk_conversation = c.id
                            WHERE m.id = @id AND fk_conversation = @conversation";
            var list = await _mysqlConnection.QueryAsync<Message, Conversation, Message>(query, (message, conversation) => {
                message.Conversation = conversation;
                return message;
            }, new { 
                id = messageId, 
                conversation = conversationId
            });
            return list.FirstOrDefault();
        }

        public async Task<List<Message>> GetAsync(int conversationId)
        {
            var query = @"SELECT * 
                            FROM messages m
                            JOIN conversations c ON m.fk_conversation = c.id
                            WHERE fk_conversation = @conversation";
            var list = await _mysqlConnection.QueryAsync<Message, Conversation, Message>(query, (message, conversation) => {
                message.Conversation = conversation;
                return message;
            }, new { conversation = conversationId });
            return list.ToList();
        }

        public async Task<int> GetAuthorAsync(int id)
        {
            var query = @"SELECT fk_author FROM messages WHERE id = @id";
            var result = await _mysqlConnection.QueryAsync<int>(query, new { id });
            return result.FirstOrDefault();
        }

        public async Task<List<Message>> GetFilteredAsync(int id)
        {
            var query = @"SELECT * FROM messages
                            WHERE conversation = @id";
            var list = await _mysqlConnection.QueryAsync<Message>(query, new { id });
            return list.ToList();
        }

        public async Task<bool> UpdateAsync(int userId, Message message, int conversationId, int messageId)
        {
            var query = @"UPDATE messages
                            SET text = @text
                            WHERE id = @id AND fk_author = @author AND fk_conversation = @conversation";

            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new
            {
                id = messageId,
                text = message.Text,
                author = userId,
                conversation = conversationId
            });
            return affectedRows > 0;
        }
    }
}
