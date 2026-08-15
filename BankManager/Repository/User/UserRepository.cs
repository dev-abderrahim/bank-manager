using BankManager.Models;
using BankManager.Repository.Database;
using Dapper;

namespace BankManager.Repository.User;

public class UserRepository(IDbConnectionFactory factory) : IUserRepository
{
    public async Task<int> AddUser(UserInput input)
    {
        using var conn = factory.CreateConnection();

        const string sql = """
                           INSERT INTO users (firstname, lastname, email, password_hash) 
                           VALUES (@Firstname, @Lastname, @Email, @Password); SELECT last_insert_rowid();
                           """;

        return await conn.ExecuteScalarAsync<int>(sql, input);
    }

    public async Task<Models.User> GetUserById(int id)
    {
        using var conn = factory.CreateConnection();

        const string sql = "SELECT * FROM users WHERE id = @id;";
        return await conn.QuerySingleAsync<Models.User>(sql, id);
    }

    public async Task<Models.User?> GetUserByEmailAndPassword(string email, string passwordHash)
    {
        using var conn = factory.CreateConnection();

        const string sql = "SELECT * FROM users WHERE email = @Email AND password_hash = @PasswordHash;";
        return await conn.QuerySingleAsync<Models.User>(sql,
            new
            {
                Email = email, PasswordHash = passwordHash
            });
    }

    public async void DeleteUser(int id)
    {
        using var conn = factory.CreateConnection();

        const string sql = "DELETE FROM users WHERE id = @id;";

        await conn.ExecuteAsync(sql, id);
    }

    public async void UpdateUser(UserInput input)
    {
        using var conn = factory.CreateConnection();

        const string sql = """
                           UPDATE users 
                           SET firstname = @Firstname, lastname = @Lastname, email = @Email, password_hash = @Password
                           WHERE id = @id;
                           """;

        await conn.ExecuteAsync(sql, input);
    }
}