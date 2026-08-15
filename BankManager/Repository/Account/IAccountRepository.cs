using BankManager.Models;

namespace BankManager.Repository.Account;

public interface IAccountRepository
{
    /// <summary>
    ///     Create a new <see cref="Account" /> for its owner.
    /// </summary>
    /// <param name="account">Account object that needs to be created.</param>
    /// <returns>The ID of the newly created account.</returns>
    Task<int> AddAccount(Models.Account account);

    /// <summary>
    ///     Fetch the <see cref="Account" /> by ID.
    /// </summary>
    /// <param name="ownerId">Account's owner ID.</param>
    /// <param name="accountId">Account ID that needs to be fetched.</param>
    /// <returns>returns <see cref="Account" />, null otherwise.</returns>
    Task<Models.Account?> GetAccountById(int ownerId, int accountId);

    /// <summary>
    ///     Fetch all accounts owned by a <see cref="User" />
    /// </summary>
    /// <param name="ownerId">The <see cref="User" /> ID</param>
    /// <returns>returns <see cref="IEnumerable{Account}" /> for found <see cref="Account" />.</returns>
    Task<IEnumerable<Models.Account>?> GetAccounts(int ownerId);

    /// <summary>
    ///     Delete a specific <see cref="Account" />
    /// </summary>
    /// <param name="ownerId"><see cref="User" /> ID</param>
    /// <param name="accountId"><see cref="Account" /> ID for deletion</param>
    void DeleteAccount(int ownerId, int accountId);

    /// <summary>
    ///     Update old infos to new one provided by <paramref name="account" /> parameter
    /// </summary>
    /// <param name="account"><see cref="Account" /> that holds the new infos</param>
    void UpdateAccount(Models.Account account);
}