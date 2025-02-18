using Domain.Arls;
using Domain.Epss;
using Domain.Pensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Seed;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    { 
        DateTime now = DateTime.Now;

        modelBuilder.Entity<Arl>().HasData(
            new ( Guid.Parse("f47a4416-8b3a-4e6c-80f4-785e7391b23f"), "Sura", now ),
            new (Guid.Parse("547f51da-9545-4a7b-b8bd-0a73c8411e26"), "Colpatria", now )
        );

        modelBuilder.Entity<Pension>().HasData(
            new (Guid.Parse("debead27-46a2-446f-8597-ab06b88695b1"), "Porvenir", now),
            new (Guid.Parse("880f4e17-7bd1-4b86-a51c-fd5b65b2c33d"), "Protección", now)
        );

        modelBuilder.Entity<Eps>().HasData(
            new (Guid.Parse("c5a65b34-334f-4355-a8b7-0098d92c7f8e"), "Sanitas", now),
            new (Guid.Parse("8e0c872e-f1f6-456a-8bcf-3a6b7a2a7c98"), "Nueva EPS", now)
        );
    }
}
