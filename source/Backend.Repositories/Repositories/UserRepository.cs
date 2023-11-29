using Backend.Core.Contracts;
using Backend.Core.Entities;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Backend.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlConnection _mysqlConnection;
        public UserRepository(MySqlConnection mysqlConnection)
        {
            _mysqlConnection = mysqlConnection;
            _mysqlConnection.Open();
        }
        public async Task<long> AddAsync(User user)
        {
            var query = @"INSERT INTO users(username, password, email)
                            VALUES(@username, @password, @email);
                            SELECT LAST_INSERT_ID();";

            var rowId = await _mysqlConnection.ExecuteScalarAsync<long>(query, new
            {
                username = user.Username,
                password = user.Password,
                email = user.Email,
            });

            return rowId;
        }

        public async Task<User?> GetAsync(int id)
        {
            var query = @"SELECT * FROM users WHERE id = @id";
            var result = await _mysqlConnection.QueryAsync<User>(query, new { id });
            return result.FirstOrDefault();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var query = @"SELECT * FROM users WHERE username = @username";
            var result = await _mysqlConnection.QueryAsync<User>(query, new { username });
            return result.FirstOrDefault();
        }

        public async Task<bool> IsAdminAsync(int id)
        {
            var query = @"SELECT * FROM admins WHERE fk_user = @id";
            var result = await _mysqlConnection.QueryAsync<User>(query, new { id });
            return result.FirstOrDefault() != null;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var query = @"UPDATE users
                            SET password = @password,
                            WHERE username = @username";

            var affectedRows = await _mysqlConnection.ExecuteAsync(query, new
            {
                username = user.Username,
                password = user.Password
            });
            return affectedRows > 0;
        }
    }
}
