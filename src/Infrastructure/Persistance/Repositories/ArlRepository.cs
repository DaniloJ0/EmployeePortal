using Domain.Arls;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class ArlRepository(ApplicationDbContext context) : IArlRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Arl Arl) => await _context.Arls.AddAsync(Arl);

    public async Task<List<Arl>> GetAll() => await _context.Arls.ToListAsync();

    public async Task<Arl?> GetByIdAsync(Guid id) => await _context.Arls.SingleOrDefaultAsync(x => x.Id == id);
}
