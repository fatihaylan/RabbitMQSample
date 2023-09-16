namespace RabbitMQ.Services;

public interface IPublisher
{
    void Publish<T>(IEnumerable<T> queueModels, string exchangeName, string queueName) where T : class, new();
}
