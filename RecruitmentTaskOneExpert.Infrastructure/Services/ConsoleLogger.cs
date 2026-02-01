using RecruitmentTaskOneExpert.Domain.Enums;
using RecruitmentTaskOneExpert.Domain.Interfaces;
using RecruitmentTaskOneExpert.Domain.Settings;

namespace RecruitmentTaskOneExpert.Infrastructure.Services;

public class ConsoleLogger : ILogger
{
    private readonly LogLevel _level;

    public ConsoleLogger(LoggingSettings settings)
    {
        _level = settings.LogLevel;
    }

    public void LogInfo(string message)
    {
        if (_level == LogLevel.Error) return;
        Write("INFO", message);
    }

    public void LogError(string message, Exception ex)
    {
        Write("ERROR", $"{message} - {ex.Message}");
    }

    private static void Write(string type, string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {type} {message}");
    }
}