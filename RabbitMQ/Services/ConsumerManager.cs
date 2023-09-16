using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Keywords;
using RabbitMQ.Models;
using System.Text;
using System.Text.Json;

namespace RabbitMQ.Services;

public class ConsumerManager : IConsumerManager
{
    private readonly IRabbitMQService _rabbitService;
    private readonly IMailSender _mailSender;
    public ConsumerManager(IRabbitMQService rabbitService, IMailSender mailSender)
    {
        _rabbitService = rabbitService;
        _mailSender = mailSender;
    }

    public async Task Consume()
    {
        try
        {
            var connection = _rabbitService.GetConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(CommonKeywords.QueueNames.NewBookNotifier, true, false, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ConsumerReceived;
            await Task.FromResult(channel.BasicConsume(CommonKeywords.QueueNames.NewBookNotifier, true, consumer));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void ConsumerReceived(object? sender, BasicDeliverEventArgs ea)
    {
        try
        {
            var mailModel = JsonSerializer.Deserialize<MailModel>(Encoding.UTF8.GetString(ea.Body.Span));
            Console.WriteLine($"Mail sending to {mailModel.To}...");
            _mailSender.SendMailAsync(mailModel).Wait();
            Console.WriteLine($"Mail sent to {mailModel.To}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while sending mail...");
            throw new Exception(ex.Message);
        }
    }
}
