namespace CarDealership.DI;

public class ServiceProvider(IEnumerable<ServiceDescriptor> serviceDescriptors)
{
    private readonly Dictionary<Type, ServiceDescriptor> _serviceDescriptors = serviceDescriptors.ToDictionary(x => x.ServiceType, x => x);
    private readonly Dictionary<Type, object> _scopedInstances = [];

    public object GetService(Type serviceType)
    {
        if (_serviceDescriptors.TryGetValue(serviceType, out var descriptor))
        {
            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation ??= CreateInstance(descriptor.ImplementationType);
                return descriptor.Implementation;
            }

            if (descriptor.Lifetime == ServiceLifetime.Scoped)
            {
                if (!_scopedInstances.TryGetValue(serviceType, out var implementation))
                {
                    implementation = CreateInstance(descriptor.ImplementationType);
                    _scopedInstances[serviceType] = implementation;
                }
                return implementation;
            }

            if (descriptor.Lifetime == ServiceLifetime.Transient)
            {
                return CreateInstance(descriptor.ImplementationType);
            }
        }

        throw new Exception($"Service of type {serviceType.Name} is not registered.");
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }

    private object CreateInstance(Type implementationType)
    {
        var constructor = implementationType.GetConstructors().First();

        var parameters = constructor.GetParameters()
            .Select(param => GetService(param.ParameterType))
            .ToArray();

        return Activator.CreateInstance(implementationType, parameters);
    }
}
