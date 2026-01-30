using RecruitmentTaskOneExpert.DI;
using RecruitmentTaskOneExpert.Domain.Interfaces;

class Program
{
    static async Task Main()
    {
        var container = Bootstrapper.Build();
        var orderService = container.Resolve<IOrderService>();
        var logger = container.Resolve<ILogger>();

        await Task.WhenAll(
            Task.Run(() => orderService.ProcessOrder(1)),
            Task.Run(() => orderService.ProcessOrder(2)),
            Task.Run(() => orderService.ProcessOrder(-1))
        );
        
        logger.LogInfo("All orders processed.");
    }
}