using Domain.Epss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration;
public class EpsConfiguration : IEntityTypeConfiguration<Eps>
{
    public void Configure(EntityTypeBuilder<Eps> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.CreatedAt);

        builder.HasMany(x => x.Employees).WithOne(x => x.Eps).HasForeignKey(x => x.EpsId);
    }
}
