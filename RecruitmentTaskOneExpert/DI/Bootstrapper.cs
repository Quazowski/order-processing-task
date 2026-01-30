using RecruitmentTaskOneExpert.Application.Services;
using RecruitmentTaskOneExpert.Domain.Interfaces;
using RecruitmentTaskOneExpert.Infrastructure.Repositories;
using RecruitmentTaskOneExpert.Infrastructure.Services;

namespace RecruitmentTaskOneExpert.DI;

public static class Bootstrapper
{
    public static ServiceContainer Build()
    {
        var container = new ServiceContainer();

        container.Register<ILogger>(_ => new ConsoleLogger());

        container.Register<IOrderRepository>(_ => new InMemoryOrderRepository());

        container.Register<IOrderService>(c => 
            new OrderService(c.Resolve<IOrderRepository>(), c.Resolve<ILogger>()));

        return container;
    }
}