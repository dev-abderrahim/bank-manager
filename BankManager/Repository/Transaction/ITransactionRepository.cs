using BankManager.Models;

namespace BankManager.Repository.Transaction;

public interface ITransactionRepository
{
    /// <summary>
    /// </summary>
    /// <param name="withdraw"></param>
    /// <returns></returns>
    Task<int> Withdraw(Withdraw withdraw);

    /// <summary>
    /// </summary>
    /// <param name="deposit"></param>
    /// <returns></returns>
    Task<int> Deposit(Deposit deposit);

    /// <summary>
    /// </summary>
    /// <param name="transfer"></param>
    /// <returns></returns>
    Task<int> Transfer(Transfer transfer);
}