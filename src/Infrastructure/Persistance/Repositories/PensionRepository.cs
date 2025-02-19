using Domain.Pensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class PensionRepository(ApplicationDbContext context) : IPensionRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Pension Pension) => await _context.Pensions.AddAsync(Pension);
    public async Task<List<Pension>> GetAll() => await _context.Pensions.ToListAsync();

    public async Task<Pension?> GetByIdAsync(Guid id) => await _context.Pensions.SingleOrDefaultAsync(x => x.Id == id);
}
