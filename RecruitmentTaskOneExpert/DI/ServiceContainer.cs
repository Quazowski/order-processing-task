namespace RecruitmentTaskOneExpert.DI;


public sealed class ServiceContainer
{
    private readonly Dictionary<Type, Func<ServiceContainer, object>> _registrations = new();

    public void Register<TService>(Func<ServiceContainer, TService> factory)
        where TService : class
    {
        _registrations[typeof(TService)] = c => factory(c)!;
    }

    public TService Resolve<TService>() where TService : class
    {
        if (!_registrations.TryGetValue(typeof(TService), out var factory))
        {
            throw new InvalidOperationException($"Service not registered: {typeof(TService).Name}");
        }

        return (TService)factory(this);
    }
}