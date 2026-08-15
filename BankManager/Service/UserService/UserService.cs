using BankManager.Models;
using BankManager.Models.Types;
using BankManager.Repository.User;
using BankManager.Utils;

namespace BankManager.Service.UserService;

public class UserService(IUserRepository userRepository, AppState state) : IUserService
{
    public async Task<ServiceResult<int>> CreateUserAsync(UserInput input)
    {
        var userId = await userRepository.AddUser(input);

        return new ServiceResult<int>(true,
            $"User created with ID: {userId}",
            userId
        );
    }

    public Task<ServiceResult> UpdateUserAsync(UserInput input)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult> DeleteUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult> ChangeEmailAsync(int userId, string oldEmail, string newEmail)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<User?>> LoginAsync(string email, string password)
    {
        var hashedPassword = Hasher.HashString(password);

        var user = await userRepository.GetUserByEmailAndPassword(email, hashedPassword);

        if (user == null)
        {
            return new ServiceResult<User?>(
                false,
                "User not found",
                null
            );
        }

        state.CurrentUserId = user.Id;
        state.CurrentUser = user;
        state.LastLogin = new DateTime();

        return new ServiceResult<User?>(
            true,
            $"User successfully logged in with ID: {user.Id}",
            user
        );
    }

    public Task<ServiceResult> LogoutAsync()
    {
        state.CleanState();

        return Task.FromResult(new ServiceResult(
            true,
            "User successfully logged out"
        ));
    }
}