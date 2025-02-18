using Domain.Epss;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class EpsRepository(ApplicationDbContext context) : IEpsRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Eps Eps) => await _context.Epss.AddAsync(Eps);  

    public async Task<Eps?> GetByIdAsync(Guid id) => await _context.Epss.SingleOrDefaultAsync(x => x.Id == id);
}
