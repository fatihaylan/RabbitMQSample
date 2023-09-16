using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Services;

namespace RabbitMQ.Consumer;

public class ServiceProviderHelper
{
    public static IServiceProvider GetServiceProvider()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.GetFullPath(Path.GetFullPath(@"../../../../Book.Api/appsettings.json"))).Build();

        return new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .AddSingleton<IRabbitMQService, RabbitMQService>()
            .AddSingleton<IPublisher, Publisher>()
            .AddSingleton<ISmtpConfiguration, SmtpConfiguration>()
            .AddSingleton<IMailSender, MailSender>()
            .AddSingleton<IConsumerManager, ConsumerManager>()
            .BuildServiceProvider();
    }
}
