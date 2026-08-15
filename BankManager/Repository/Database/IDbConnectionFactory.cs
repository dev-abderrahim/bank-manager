using System.Data;

namespace BankManager.Repository.Database;

public interface IDbConnectionFactory
{
    /// <summary>
    ///     An interface to handle creation of connections to DataBase
    /// </summary>
    /// <returns>returns the <see cref="IDbConnection" /> interface.</returns>
    /// <example>
    ///     <code>
    /// using var conn = factory.CreateConnection();
    /// conn.ExecuteQuery(query);
    /// </code>
    /// </example>
    IDbConnection CreateConnection();
}