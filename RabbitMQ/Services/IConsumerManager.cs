namespace RabbitMQ.Services;

public interface IConsumerManager
{
    Task Consume();
}
