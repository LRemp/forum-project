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

        public async Task<int> AddAsync(Channel channel, int userId)
        {
            

            var result = await _mysqlConnection.QueryAsync<Channel>(@"SELECT * FROM channels WHERE name = @name LIMIT 1", new { name = channel.Name });
            var dbChannel = result.FirstOrDefault();

            if(dbChannel != null)
            {
                //throw an exception
                throw new Exception();
            }

            var query = @"INSERT INTO channelrequests(fk_user, name, description)
                            VALUES(@author, @name, @description);
                            SELECT LAST_INSERT_ID();";

            var id = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                author = userId,
                name = channel.Name,
                description = channel.Description
            });

            return (int)id;
        }

        public async Task<int> ApproveRequestAsync(int id)
        {
            var requestQuery = @"SELECT * FROM channelrequests WHERE id = @id LIMIT 1";
            var requestResult = await _mysqlConnection.QueryAsync<ChannelRequest>(requestQuery, new { id });
            var request = requestResult.FirstOrDefault();

            if(request == null)
            {
                // TODO: correct the exception
                throw new Exception();
            }
            
            var query = @"INSERT INTO channels(name, description)
                            VALUES(@name, @description);
                            SELECT LAST_INSERT_ID();";
            var resultId = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                name = request.Name,
                description = request.Description
            });

            await _mysqlConnection.QueryAsync(@"DELETE FROM channelrequests WHERE id = @id", new { id });

            return (int)resultId;
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

        public async Task<List<ChannelRequestDTO>> GetRequests()
        {
            var query = @"SELECT * FROM channelrequests";
            var result = await _mysqlConnection.QueryAsync<ChannelRequestDTO>(query);
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
