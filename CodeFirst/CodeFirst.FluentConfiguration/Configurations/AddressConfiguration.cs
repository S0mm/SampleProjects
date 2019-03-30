using CodeFirst.FluentConfiguration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.FluentConfiguration.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address"); // by default is 'Addresses'
            builder.Property(p => p.Country).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Line1).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Line2).HasMaxLength(100);
        }
    }
}
