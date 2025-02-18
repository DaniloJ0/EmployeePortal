using Domain.Employees;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasConversion(
                employeeId => employeeId.Value,
                value => new EmployeeId(value));

        builder.HasOne(c => c.Arl)
            .WithMany(c => c.Employees)
            .HasForeignKey(c => c.ArlId);

        builder.HasOne(c => c.Pension)
            .WithMany(c => c.Employees)
            .HasForeignKey(c => c.PensionId);
        
        builder.HasOne(c => c.Eps)
            .WithMany(c => c.Employees)
            .HasForeignKey(c => c.EpsId);

        builder.Property(c => c.Name).HasMaxLength(100);

        builder.Property(c => c.Cedula).HasMaxLength(11);

        builder.Property(c => c.BloodType).HasMaxLength(3);

        builder.Property(c => c.Phone)
           .HasConversion(
               customerId => customerId.Value,
               value => PhoneNumber.Create(value)!)
            .HasMaxLength(9);

        builder.Property(c => c.CreatedAt);

    }
}
