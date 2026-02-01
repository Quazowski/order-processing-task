using RecruitmentTaskOneExpert.Domain.Entities;
using RecruitmentTaskOneExpert.Domain.Interfaces;

namespace RecruitmentTaskOneExpert.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IOrderValidator _validator;
    private readonly INotificationService _notifier;
    private readonly ILogger _logger;

    public OrderService(IOrderRepository repository, IOrderValidator validator, INotificationService notifier, ILogger logger)
    {
        _repository = repository;
        _validator = validator;
        _notifier = notifier;
        _logger = logger;
    }

    public async Task ProcessOrderAsync(int orderId)
    {
        try
        {
            _logger.LogInfo($"Starting processing for order {orderId}");

            await Task.Delay(100);
            
            if (!_validator.IsValid(orderId))
            {
                _logger.LogError($"Order {orderId} is invalid.", new ArgumentException("Validation failed"));
                
                return;
            }
            
            string description = _repository.GetOrder(orderId);

            _logger.LogInfo($"Order {orderId} processed successfully. The order description is: {description}");
            _notifier.Send($"Order {orderId} processed successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to process order {orderId}", ex);
        }
    }

    public void AddOrder(Order order)
    {
        try
        {
            _logger.LogInfo("Adding a new order.");

            _repository.AddOrder(order);

            _logger.LogInfo("The new order was added successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to add order with ID: {order.Id}", ex);
        }
    }
}