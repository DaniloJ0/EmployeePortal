using Domain.ValueObjects;

namespace Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id);
    Task Add(User User);
    Task<bool> GetByEmail(Email email);
    Task<User?> GetByEmailAsync(Email email);
}
