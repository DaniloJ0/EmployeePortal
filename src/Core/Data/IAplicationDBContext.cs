using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Microsoft.EntityFrameworkCore;

namespace HR_Platform.Application.Data;

public interface IApplicationDBContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Arl> Arls { get; set; }
    public DbSet<Pension> Pensions { get; set; }
    public DbSet<Eps> Epss { get; set; }
}