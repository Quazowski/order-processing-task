using RecruitmentTaskOneExpert.Domain.Entities;

namespace RecruitmentTaskOneExpert.Domain.Interfaces;

public interface IOrderService
{
    Task ProcessOrderAsync(int orderId);
    void AddOrder(Order order);
}