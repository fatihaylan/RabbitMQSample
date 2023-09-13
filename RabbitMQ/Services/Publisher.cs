using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Keywords;

namespace RabbitMQ.Services
{
    public class Publisher : IPublisher
    {
        private IConnection? _connection;
        private IModel? _channel;
        private readonly IRabbitMQService _rabbitService;

        public Publisher(IRabbitMQService rabbitService) => _rabbitService = rabbitService;

        public void Publish<T>(IEnumerable<T> queueModels, string exchangeName, string queueName) where T : class, new()
        {
            try
            {
                _connection = _rabbitService.GetConnection();
                using (_channel = _rabbitService.GetChannel(_connection))
                {
                    _channel.ExchangeDeclare(exchangeName, CommonKeywords.ExchangeTypes.Direct);
                    _channel.QueueDeclare(queueName, true, false, false);
                    _channel.QueueBind(queueName, exchangeName, queueName);

                    foreach (var model in queueModels)
                    {
                        var body = JsonSerializer.SerializeToUtf8Bytes(model);
                        _channel.BasicPublish(exchangeName, queueName, null, body);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
