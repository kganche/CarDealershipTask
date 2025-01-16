
namespace CarDealership.Api.Services;

public class SingletonService : ISingletonService
{
    private readonly Guid _instanceId;

    public SingletonService()
    {
        _instanceId = Guid.NewGuid();
    }

    public Guid GetInstanceId() => _instanceId;
}
