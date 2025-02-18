using Domain.Arls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration;
public class ArlConfiguration : IEntityTypeConfiguration<Arl>
{
    public void Configure(EntityTypeBuilder<Arl> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.CreatedAt);

        builder.HasMany(x => x.Employees).WithOne(x => x.Arl).HasForeignKey(x => x.ArlId);
    }
}
