using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.PurchasePrice)
            .IsRequired()
            .HasColumnType("money");

        builder
            .HasOne(o => o.Client)
            .WithMany()
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(o => o.Store)
            .WithMany()
            .HasForeignKey(o => o.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(o => o.Car)
            .WithMany()
            .HasForeignKey(o => o.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}