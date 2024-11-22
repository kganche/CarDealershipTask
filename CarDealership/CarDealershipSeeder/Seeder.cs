using Bogus;
using Data.Models;

namespace CarDealershipSeeder;

public static class Seeder
{
    public static async Task SeedCarDealershipDataAsync()
    {
        using var dbContext = DbContextProvider.GetCarDealershipDbContext();

        var faker = new Faker();

        var clients = Enumerable
            .Range(1, 100)
            .Select(id => new Client
            {
                Id = id,
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName()
            })
            .ToList();
        
        await dbContext.Clients.AddRangeAsync(clients);

        var stores = Enumerable
            .Range(1, 10)
            .Select(id => new Store
            {
                Id = id,
                Name = $"Store {id}",
                Address = faker.Address.StreetAddress(),
                City = faker.Address.City()
            })
            .ToList();
        
        await dbContext.Stores.AddRangeAsync(stores);

        var cars = Enumerable
            .Range(1, 50)
            .Select(id => new Car
            {
                Id = id,
                Manufacturer = faker.Vehicle.Manufacturer(),
                Model = faker.Vehicle.Model(),
                Price = Math.Round((decimal)faker.Random.Double(20000, 100000), 2)
            })
            .ToList();
        
        await dbContext.Cars.AddRangeAsync(cars);

        var orders = Enumerable
            .Range(1, 200)
            .Select(id => new Order
            {
                Id = id,
                ClientId = faker.PickRandom(clients).Id,
                StoreId = faker.PickRandom(stores).Id,
                CarId = faker.PickRandom(cars).Id,
                PurchasePrice = Math.Round((decimal)faker.Random.Double(20000, 100000), 2)
            })
            .ToList();
        
        await dbContext.Orders.AddRangeAsync(orders);

        await dbContext.SaveChangesAsync();
    }
}