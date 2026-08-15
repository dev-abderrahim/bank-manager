using BankManager.Models;
using BankManager.Models.Types;

namespace BankManager.Service.AccountService;

public interface IAccountService
{
    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Task<ServiceResult<int>> CreateAccountAsync(string name);

    /// <summary>
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public Task<ServiceResult> UpdateAccountAsync(Account account);

    /// <summary>
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public Task<ServiceResult> DeleteAccountAsync(int accountId);

    /// <summary>
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public Task<ServiceResult<Account>> GetAccountAsync(int accountId);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public Task<ServiceResult<IEnumerable<Account>>> GetAllAccountsAsync();
}