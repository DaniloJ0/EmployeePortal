﻿
using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using Core.Data;
using Infrastructure.Persistance.Seed;
using Microsoft.EntityFrameworkCore;
using Domain.Primitives;

namespace Infrastructure.Persistance;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDBContext, IUnitOfWork
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Arl> Arls { get; set; }
    public DbSet<Pension> Pensions { get; set; }
    public DbSet<Eps> Epss { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
 
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}
