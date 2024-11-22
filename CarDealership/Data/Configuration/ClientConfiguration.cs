using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        
        builder.ToTable("Client");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);
        
        builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);
    }
}