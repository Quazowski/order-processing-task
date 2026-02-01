using Microsoft.Extensions.Configuration;
using RecruitmentTaskOneExpert.Application.Services;
using RecruitmentTaskOneExpert.Domain.Enums;
using RecruitmentTaskOneExpert.Domain.Interfaces;
using RecruitmentTaskOneExpert.Domain.Settings;
using RecruitmentTaskOneExpert.Infrastructure.Repositories;
using RecruitmentTaskOneExpert.Infrastructure.Services;

namespace RecruitmentTaskOneExpert.DI;

public static class Bootstrapper
{
    public static ServiceContainer Build()
    {
        var container = new ServiceContainer();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var loggingSettings = new LoggingSettings
        {
            LogLevel = Enum.TryParse<LogLevel>(config["Logging:LogLevel"], true, out var level) ? level : LogLevel.Info
        };

        container.Register<LoggingSettings>(_ => loggingSettings);

        container.Register<ILogger>(c => new ConsoleLogger(c.Resolve<LoggingSettings>()));
        container.Register<IOrderRepository>(_ => new InMemoryOrderRepository());
        container.Register<IOrderValidator>(_ => new OrderValidator());
        container.Register<INotificationService>(_ => new ConsoleNotificationService());

        container.Register<IOrderService>(c =>
            new OrderService(
                c.Resolve<IOrderRepository>(),
                c.Resolve<IOrderValidator>(),
                c.Resolve<INotificationService>(),
                c.Resolve<ILogger>()));

        return container;
    }
}
