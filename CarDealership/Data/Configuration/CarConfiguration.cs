using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Car");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Manufacturer)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(c => c.Price)
            .IsRequired()
            .HasColumnType("money");
    }
}