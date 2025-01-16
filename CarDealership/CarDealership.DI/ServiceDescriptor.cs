﻿namespace CarDealership.DI;

public class ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
{
    public Type ServiceType { get; } = serviceType;

    public Type ImplementationType { get; } = implementationType;

    public ServiceLifetime Lifetime { get; } = lifetime;

    public object Implementation { get; set; }
}
