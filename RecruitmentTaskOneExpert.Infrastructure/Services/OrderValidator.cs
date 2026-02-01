using RecruitmentTaskOneExpert.Domain.Interfaces;

namespace RecruitmentTaskOneExpert.Infrastructure.Services;

public class OrderValidator : IOrderValidator
{
    public bool IsValid(int orderId)
    {
        return orderId > 0;
    }
}