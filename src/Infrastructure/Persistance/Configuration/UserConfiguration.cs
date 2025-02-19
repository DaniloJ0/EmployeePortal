using Domain.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasConversion(
                UserId => UserId.Value,
                value => new UserId(value));

        builder.Property(c => c.Email)
           .HasConversion(
               email => email.Value,
               value => Email.Create(value)!)
            .HasMaxLength(9);

        builder.Property(c => c.Password)
            .HasMaxLength(30);
        

        builder.Property(c => c.CreatedAt);

    }
}
