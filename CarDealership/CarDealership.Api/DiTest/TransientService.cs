
namespace CarDealership.Api.Services;

public class TransientService : ITransientService
{
    private readonly Guid _instanceId;

    public TransientService()
    {
        _instanceId = Guid.NewGuid();
    }

    public Guid GetInstanceId() => _instanceId;
}
