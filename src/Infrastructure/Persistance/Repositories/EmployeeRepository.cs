using Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Employee Employee) => await _context.Employees.AddAsync(Employee);  

    public async Task<Employee?> GetByIdAsync(EmployeeId id) => await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
    public async Task<List<Employee>> GetAll() => await _context.Employees
        .AsNoTracking()
        .Include(p => p.Pension)
        .Include(e => e.Eps)
        .Include(a => a.Arl)
        .ToListAsync();

    public async Task<bool> GetByIdentification(string identification) => await _context.Employees.AnyAsync(x => x.Cedula == identification);

    public void Delete(Employee employee) => _context.Employees.Remove(employee);
    public void Update(Employee employee) => _context.Employees.Update(employee);
}
