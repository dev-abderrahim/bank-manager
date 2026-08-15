namespace BankManager.Models;

public record UserInput(
    string Firstname,
    string Lastname,
    string Email,
    string Password,
    string? OldPassword
);