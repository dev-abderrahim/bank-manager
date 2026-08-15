using System.Security.Cryptography;
using System.Text;

namespace BankManager.Utils;

public class Hasher
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string HashString(string input)
    {
        return SHA256.HashData(Encoding.UTF8.GetBytes(input)).ToString()!;
    }
}