namespace BankManager.Models;

public record User(
    int Id,
    string Firstname,
    string Lastname,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    IEnumerable<int>? AccountsIds
);