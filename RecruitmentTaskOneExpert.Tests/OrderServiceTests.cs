using Moq;
using RecruitmentTaskOneExpert.Application.Services;
using RecruitmentTaskOneExpert.Domain.Interfaces;

namespace RecruitmentTaskOneExpert.Tests;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _repoMock;
    private readonly Mock<ILogger> _loggerMock;
    private readonly Mock<IOrderValidator> _validatorMock;
    private readonly Mock<INotificationService> _notificationMock;
    private readonly OrderService _service;

    public OrderServiceTests()
    {
        _repoMock = new Mock<IOrderRepository>();
        _loggerMock = new Mock<ILogger>();
        _validatorMock = new Mock<IOrderValidator>();
        _notificationMock = new Mock<INotificationService>();

        _service = new OrderService(
            _repoMock.Object,
            _validatorMock.Object,
            _notificationMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async Task ProcessOrderAsync_HappyPath_LogsSuccess()
    {
        _validatorMock.Setup(v => v.IsValid(1)).Returns(true);
        _repoMock.Setup(r => r.GetOrder(1)).Returns("Laptop");

        await _service.ProcessOrderAsync(1);

        _loggerMock.Verify(l =>
                l.LogInfo(It.Is<string>(s => s.Contains("processed"))),
            Times.Once);
    }

    [Fact]
    public async Task ProcessOrderAsync_InvalidId_LogsValidationError()
    {
        _validatorMock.Setup(v => v.IsValid(-1)).Returns(false);

        await _service.ProcessOrderAsync(-1);

        _loggerMock.Verify(l =>
                l.LogError(It.IsAny<string>(), It.IsAny<Exception>()),
            Times.Once);
    }

    [Fact]
    public async Task ProcessOrderAsync_NotFound_LogsException()
    {
        _validatorMock.Setup(v => v.IsValid(99)).Returns(true);
        _repoMock.Setup(r => r.GetOrder(99))
            .Throws(new KeyNotFoundException());

        await _service.ProcessOrderAsync(99);

        _loggerMock.Verify(l =>
                l.LogError(It.Is<string>(s => s.Contains("Failed")), It.IsAny<Exception>()),
            Times.Once);
    }
}