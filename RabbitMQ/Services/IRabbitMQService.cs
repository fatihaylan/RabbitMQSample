using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQ.Services
{
    public interface IRabbitMQService
    {
        IConnection GetConnection();
        IModel GetChannel(IConnection  connection);
    }
}
