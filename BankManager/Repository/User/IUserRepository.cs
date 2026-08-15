namespace BankManager.Repository.User;

public interface IUserRepository
{
    /// <summary>
    ///     Create a new <see cref="User" />
    /// </summary>
    /// <param name="user">Infos of the user to be created</param>
    /// <returns>returns the ID of the newly created user</returns>
    Task<int> AddUser(Models.UserInput user);

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Models.User> GetUserById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    Task<Models.User?> GetUserByEmailAndPassword(string email, string passwordHash);

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    void DeleteUser(int id);

    /// <summary>
    /// </summary>
    /// <param name="user"></param>
    void UpdateUser(Models.UserInput user);
}