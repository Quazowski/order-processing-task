using RecruitmentTaskOneExpert.Domain.Interfaces;

namespace RecruitmentTaskOneExpert.Infrastructure.Services;

public class ConsoleLogger : ILogger
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] INFO  - {message}");
    }

    public void LogError(string message, Exception ex)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] ERROR - {message}");
        
        Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
    }
}