namespace CarDealership.DI;

public class CustomScope(ServiceProvider serviceProvider) : IDisposable
{
    private readonly ServiceProvider _serviceProvider = serviceProvider;
    private readonly Dictionary<Type, object> _scopedInstances = [];

    public T GetService<T>()
    {
        var serviceType = typeof(T);

        if (!_scopedInstances.TryGetValue(serviceType, out var implementation))
        {
            implementation = _serviceProvider.GetService(serviceType);
            _scopedInstances[serviceType] = implementation;
        }

        return (T)implementation;
    }

    public void Dispose() => _scopedInstances.Clear();
}
