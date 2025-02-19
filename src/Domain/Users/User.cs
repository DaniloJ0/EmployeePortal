using Domain.ValueObjects;

namespace Domain.Users;

public class User(UserId id, Email email, string password, DateTime createdAt)
{
    public UserId Id { get; set; } = id;
    public Email Email { get; set; } = email;
    public string Password { get; set; } = password;
    public DateTime CreatedAt { get; set; } = createdAt;
}
