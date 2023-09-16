using RabbitMQ.Models;
using System.Net.Mail;
using System.Net;

namespace RabbitMQ.Services;

public class MailSender : IMailSender
{
    private readonly ISmtpConfiguration _smtpConfiguration;
    public MailSender(ISmtpConfiguration smtpConfiguration) => _smtpConfiguration = smtpConfiguration;

    public async Task SendMailAsync(MailModel mailModel)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(mailModel.From))
                mailModel.From = _smtpConfiguration.User;

            var mailMessage = mailModel.ToMailMessage();

            using var client = CreateSmtpClient(_smtpConfiguration);
            await client.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public SmtpClient CreateSmtpClient(ISmtpConfiguration smtpConfiguration)
    {
        return new SmtpClient(smtpConfiguration.Host, smtpConfiguration.Port)
        {
            EnableSsl = smtpConfiguration.UseSSL,
            UseDefaultCredentials = true,
            Credentials = new NetworkCredential(smtpConfiguration.User, smtpConfiguration.Password)
        };
    }
}
