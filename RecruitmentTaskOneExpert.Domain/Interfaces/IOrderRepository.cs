using RecruitmentTaskOneExpert.Domain.Entities;

namespace RecruitmentTaskOneExpert.Domain.Interfaces;

public interface IOrderRepository
{
    string GetOrder(int orderId);
    void AddOrder(Order order);
}