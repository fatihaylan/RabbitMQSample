using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Services
{
    public interface IPublisher
    {
        void Publish<T>(IEnumerable<T> queueModels, string exchangeName, string queueName) where T : class, new();
    }
}
