using CarDealership.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarDealership.DataSeeder;

public static class DbContextProvider
{
    public static CarDealershipDbContext GetCarDealershipDbContext()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<AssemblyReference>()
            .Build();

        var options = new DbContextOptionsBuilder<CarDealershipDbContext>()
            .UseSqlServer(configuration["ConnectionString"])
            .Options;

        return new CarDealershipDbContext(options);
    }
}