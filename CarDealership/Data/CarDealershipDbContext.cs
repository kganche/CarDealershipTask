using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CarDealershipDbContext(DbContextOptions<CarDealershipDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<Store> Stores { get; set; }
    
    public DbSet<Car> Cars { get; set; }
    
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarDealershipDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}