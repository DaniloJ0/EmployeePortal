using Domain.Pensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration;
public class PensionConfiguration : IEntityTypeConfiguration<Pension>
{
    public void Configure(EntityTypeBuilder<Pension> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.CreatedAt);

        builder.HasMany(x => x.Employees).WithOne(x => x.Pension).HasForeignKey(x => x.PensionId);
    }
}
