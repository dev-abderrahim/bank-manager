using BankManager.Models;
using BankManager.Models.Types;

namespace BankManager.Service.UserService;

public interface IUserService
{
    /// <summary>
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Returns the ID of created <see cref="User" /></returns>
    public Task<ServiceResult<int>> CreateUserAsync(UserInput user);

    /// <summary>
    /// </summary>
    /// <param name="user"></param>
    public Task<ServiceResult> UpdateUserAsync(UserInput user);

    /// <summary>
    /// </summary>
    /// <param name="userId"></param>
    public Task<ServiceResult> DeleteUserAsync(int userId);

    /// <summary>
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="oldPassword"></param>
    /// <param name="newPassword"></param>
    public Task<ServiceResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword);

    /// <summary>
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="oldEmail"></param>
    /// <param name="newEmail"></param>
    public Task<ServiceResult> ChangeEmailAsync(int userId, string oldEmail, string newEmail);

    /// <summary>
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    public Task<ServiceResult<User?>> LoginAsync(string email, string password);

    /// <summary>
    /// </summary>
    public Task<ServiceResult> LogoutAsync();
}