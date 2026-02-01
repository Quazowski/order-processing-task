using RecruitmentTaskOneExpert.Domain.Interfaces;

namespace RecruitmentTaskOneExpert.Infrastructure.Services;


public class ConsoleNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"[NOTIFY] {message}");
    }
}