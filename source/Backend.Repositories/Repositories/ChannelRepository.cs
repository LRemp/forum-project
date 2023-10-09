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
    public class ChannelRepository : IChannelRepository
    {
        private readonly MySqlConnection _mysqlConnection;
        public ChannelRepository(MySqlConnection mysqlConnection)
        {
            _mysqlConnection = mysqlConnection;
            _mysqlConnection.Open();
        }

        public async Task<long> AddAsync(Channel channel)
        {
            var query = @"INSERT INTO channels(name, description)
                            VALUES(@name, @description);
                            SELECT LAST_INSERT_ID();";

            var rowId = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                name = channel.Name,
                description = channel.Description
            });
            return rowId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"DELETE FROM channels WHERE id = @id";
            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new { id });
            return affectedRows > 0;
        }

        public async Task<Channel?> GetAsync(int id)
        {
            var query = @"SELECT * FROM channels WHERE id = @id";
            var result = await _mysqlConnection.QueryAsync<Channel>(query, new { id });
            return result.FirstOrDefault();
        }

        public async Task<List<Channel>> GetAsync()
        {
            var query = @"SELECT * FROM channels";
            var result = await _mysqlConnection.QueryAsync<Channel>(query);
            return result.ToList();
        }

        public async Task<bool> UpdateAsync(Channel channel)
        {
            var query = @"UPDATE channels
                            SET description = @description
                            WHERE id = @id";
            
            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new
            {
                id = channel.Id,
                name = channel.Name,
                description = channel.Description
            });
            return affectedRows > 0;
        }
    }
}
