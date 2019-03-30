using CodeFirst.FluentConfiguration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.FluentConfiguration.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.AddressId).IsRequired(false);
            builder.Property(p => p.CompanyId).IsRequired();
        }
    }
}
