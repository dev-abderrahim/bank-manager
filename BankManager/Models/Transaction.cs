namespace BankManager.Models;

public abstract class Transaction(
    int id,
    DateTime createdAt,
    decimal amount
)
{
    /// <summary>
    /// </summary>
    public int Id { get; init; } = id;

    /// <summary>
    /// </summary>
    public DateTime CreatedAt { get; init; } = createdAt;

    /// <summary>
    /// </summary>
    public decimal Amount { get; init; } = amount;
}

public class Deposit(
    int id,
    DateTime createdAt,
    decimal amount,
    int toAccountId
) : Transaction(id, createdAt, amount)
{
    /// <summary>
    /// </summary>
    public int ToAccount { get; init; } = toAccountId;
}

public class Withdraw(
    int id,
    DateTime createdAt,
    decimal amount,
    int fromAccountId
) : Transaction(id, createdAt, amount)
{
    /// <summary>
    /// </summary>
    public int FromAccount { get; init; } = fromAccountId;
}

public class Transfer(
    int id,
    DateTime createdAt,
    decimal amount,
    int toAccountId,
    int fromAccountId
) : Transaction(id, createdAt, amount)
{
    /// <summary>
    /// </summary>
    public int ToAccount { get; init; } = toAccountId;

    /// <summary>
    /// </summary>
    public int FromAccount { get; init; } = fromAccountId;
}

/// <summary>
/// </summary>
public enum TransactionType
{
    Withdraw,
    Deposit,
    Transfer
}