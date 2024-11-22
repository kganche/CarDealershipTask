using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Store");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(s => s.Address)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(s => s.City)
            .IsRequired()
            .HasMaxLength(50);
    }
}