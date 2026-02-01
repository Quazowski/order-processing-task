namespace RecruitmentTaskOneExpert.Domain.Interfaces;

public interface IOrderValidator
{
    bool IsValid(int orderId);
}