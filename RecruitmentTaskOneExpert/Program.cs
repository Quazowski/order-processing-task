using RecruitmentTaskOneExpert.DI;
using RecruitmentTaskOneExpert.Domain.Entities;
using RecruitmentTaskOneExpert.Domain.Interfaces;

class Program
{
    static async Task Main()
    {
        var newOrderId = 3;
        
        var container = Bootstrapper.Build();
        var orderService = container.Resolve<IOrderService>();
        var logger = container.Resolve<ILogger>();

        logger.LogInfo("Order Processing System.");
        
        await Task.WhenAll(
            orderService.ProcessOrderAsync(1),
            orderService.ProcessOrderAsync(2),
            orderService.ProcessOrderAsync(-1)
        );
        
        logger.LogInfo("Processing complete.");

        orderService.AddOrder(new Order
        {
            Id = newOrderId,
            Description = "Desktop"
        });
    }
}