using BankManager.Models;
using BankManager.Repository.Database;
using Dapper;

namespace BankManager.Repository.Transaction;

public class TransactionRepository(IDbConnectionFactory factory) : ITransactionRepository
{
    public async Task<int> Withdraw(Withdraw withdraw)
    {
        using var conn = factory.CreateConnection();

        const string query = """
                             INSERT INTO transactions (created_at, amount, from_account)
                             VALUES (@CreatedAt, @Amount, @FromAccount); SELECT last_insert_rowid();
                             """;

        return await conn.ExecuteScalarAsync<int>(query, withdraw);
    }

    public async Task<int> Deposit(Deposit deposit)
    {
        using var conn = factory.CreateConnection();

        const string query = """
                             INSERT INTO transactions (created_at, amount, to_account)
                             VALUES (@CreatedAt, @Amount, @ToAccount); SELECT last_insert_rowid();
                             """;

        return await conn.ExecuteScalarAsync<int>(query, deposit);
    }

    public async Task<int> Transfer(Transfer transfer)
    {
        using var conn = factory.CreateConnection();

        const string query = """
                             INSERT INTO transactions (created_at, amount, from_account, to_account)
                             VALUES (@CreatedAt, @Amount, @FromAccount,@ToAccount); SELECT last_insert_rowid();
                             """;

        return await conn.ExecuteScalarAsync<int>(query, transfer);
    }
}