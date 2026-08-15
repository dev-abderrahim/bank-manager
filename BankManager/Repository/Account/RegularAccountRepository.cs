using BankManager.Repository.Database;
using Dapper;

namespace BankManager.Repository.Account;

public class RegularAccountRepository(IDbConnectionFactory factory) : IAccountRepository
{
    public async Task<int> AddAccount(Models.Account account)
    {
        using var conn = factory.CreateConnection();

        const string sql = """
                           INSERT INTO accounts (name, balance, owner_id)
                           VALUES (@Name, @Balance, @OwnerId); SELECT last_insert_rowid();
                           """;

        return await conn.ExecuteScalarAsync<int>(sql, account);
    }

    public async Task<Models.Account?> GetAccountById(int ownerId, int accountId)
    {
        using var conn = factory.CreateConnection();

        const string sql = """
                           SELECT * FROM accounts WHERE id = @AccountId AND owner_id = @OwnerId;
                           """;

        return await conn.QuerySingleOrDefaultAsync<Models.Account>(sql,
            new { AccountId = accountId, OwnerId = ownerId });
    }

    public async Task<IEnumerable<Models.Account>?> GetAccounts(int ownerId)
    {
        using var conn = factory.CreateConnection();

        const string sql = """
                           SELECT * FROM accounts WHERE owner_id = @OwnerId;
                           """;

        return await conn.QueryAsync<Models.Account>(sql, new { OwnerId = ownerId });
    }

    public void DeleteAccount(int ownerId, int accountId)
    {
        using var conn = factory.CreateConnection();
        const string sql = """
                           DELETE FROM accounts
                           WHERE id = @AccountId AND owner_id = @OwnerId;
                           """;
        conn.ExecuteAsync(sql, new { AccountId = accountId, OwnerId = ownerId });
    }

    public void UpdateAccount(Models.Account account)
    {
        using var conn = factory.CreateConnection();

        const string sql = """
                           UPDATE accounts 
                           SET name = @Name, balance = @Balance
                           WHERE id = @Id AND owner_id = @OwnerId;
                           """;

        conn.ExecuteAsync(sql, account);
    }
}