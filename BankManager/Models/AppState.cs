namespace BankManager.Models;

public class AppState
{
    public int? CurrentUserId { get; set; }
    public int? CurrentAccountId { get; set; }
    public User? CurrentUser { get; set; }
    public Account? CurrentAccount { get; set; }
    public bool IsLoggedIn => CurrentUserId.HasValue;
    public bool IsDirtyChanges { get; set; } = false;
    public DateTime? LastLogin { get; set; }
    public string? DatabasePath { get; set; }

    /// <summary>
    /// Clean the cached app state such as current <see cref="User"/> ID,
    /// and its cached object
    /// </summary>
    public void CleanState()
    {
        CurrentUserId = null;
        CurrentAccountId = null;
        CurrentUser = null;
        CurrentAccount = null;
        IsDirtyChanges = false;
    }

    /// <summary>
    /// Full reset to app state
    /// </summary>
    public void CleanFullState()
    {
        CurrentUserId = null;
        CurrentAccountId = null;
        CurrentUser = null;
        CurrentAccount = null;
        IsDirtyChanges = false;
        LastLogin = null;
        DatabasePath = null;
    }
}