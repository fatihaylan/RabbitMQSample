using RabbitMQ.Models;

namespace RabbitMQ.Services;

public interface IMailSender
{
    Task SendMailAsync(MailModel mailModel);
}
