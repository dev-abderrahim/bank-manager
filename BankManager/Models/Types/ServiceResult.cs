namespace BankManager.Models.Types;

public record ServiceResult<T>(
    bool Success,
    string Message,
    T? Result
);

public record ServiceResult(
    bool Success,
    string Message
);