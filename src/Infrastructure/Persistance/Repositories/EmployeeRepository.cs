using Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Employee Employee) => await _context.Employees.AddAsync(Employee);  

    public async Task<Employee?> GetByIdAsync(EmployeeId id) => await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
}
