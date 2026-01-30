using RecruitmentTaskOneExpert.Domain.Interfaces;

namespace RecruitmentTaskOneExpert.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly ILogger _logger;

    public OrderService(IOrderRepository repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void ProcessOrder(int orderId)
    {
        try
        {
            _logger.LogInfo($"Starting processing for order {orderId}");
            
            string description = _repository.GetOrder(orderId);

            _logger.LogInfo($"Order {orderId} processed successfully. The order description is: {description}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to process order {orderId}", ex);
        }
    }
}