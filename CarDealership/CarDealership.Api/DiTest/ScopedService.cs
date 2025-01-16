
namespace CarDealership.Api.Services;

public class ScopedService : IScopedService
{
    private readonly Guid _instanceId;

    public ScopedService()
    {
        _instanceId = Guid.NewGuid();
    }

    public Guid GetInstanceId() => _instanceId;
}
