using Domain.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(User User) => await _context.Users.AddAsync(User);

    public async Task<bool> GetByEmail(Email email) => await _context.Users.AnyAsync(x => x.Email == email);
    public async Task<User?> GetByEmailAsync(Email email) => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

    public async Task<User?> GetByIdAsync(UserId id) => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
 
}
