using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace RabbitMQ.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConfiguration _configuration;
        public RabbitMQService(IConfiguration configuration) => _configuration = configuration;

        public IConnection GetConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("RabbitMqConfig:HostName").Value,
                UserName = _configuration.GetSection("RabbitMqConfig:UserName").Value,
                Password = _configuration.GetSection("RabbitMqConfig:Password").Value
            };
            return factory.CreateConnection();
        }

        public IModel GetChannel(IConnection connection) => connection.CreateModel();
    }
}
