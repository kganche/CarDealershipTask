using CarDealership.Api.Services;
using CarDealership.DI;

namespace CarDealership.Api.DiTest;

public class LifetimeTest
{
    public static void RunTests(DI.ServiceProvider provider)
    {
        Console.WriteLine("=== Transient Lifetime Test ===");

        var transient1 = provider.GetService<ITransientService>();
        var transient2 = provider.GetService<ITransientService>();

        Console.WriteLine($"Transient 1: {transient1.GetInstanceId()}");
        Console.WriteLine($"Transient 2: {transient2.GetInstanceId()}");

        Console.WriteLine("\n=== Scoped Lifetime Test ===");
        using (var scope1 = new CustomScope(provider))
        {
            var scoped1 = scope1.GetService<IScopedService>();
            var scoped2 = scope1.GetService<IScopedService>();
            Console.WriteLine($"Scoped (Same Scope) 1: {scoped1.GetInstanceId()}");
            Console.WriteLine($"Scoped (Same Scope) 2: {scoped2.GetInstanceId()}");
        }

        using (var scope2 = new CustomScope(provider))
        {
            var scoped3 = scope2.GetService<ITransientService>();
            Console.WriteLine($"Scoped (New Scope) 3: {scoped3.GetInstanceId()}");
        }

        Console.WriteLine("\n=== Singleton Lifetime Test ===");
        var singleton1 = provider.GetService<ISingletonService>();
        var singleton2 = provider.GetService<ISingletonService>();
        Console.WriteLine($"Singleton 1: {singleton1.GetInstanceId()}");
        Console.WriteLine($"Singleton 2: {singleton2.GetInstanceId()}");
    }
}
