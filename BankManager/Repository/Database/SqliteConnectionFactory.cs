using System.Data;
using Microsoft.Data.Sqlite;

namespace BankManager.Repository.Database;

public class SqliteConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(connectionString);
    }
}