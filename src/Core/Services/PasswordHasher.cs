using Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Core.Servicess;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new();
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string hash = HashPassword(password);
        return hash == hashedPassword;
    }
}
