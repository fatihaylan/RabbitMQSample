using System.Net.Mail;

namespace RabbitMQ.Models;

public class MailModel
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

public static class MailModelExtensions{
    public static MailMessage ToMailMessage(this MailModel model)
    {
        return new MailMessage()
        {
            To = { model.To },
            From = new MailAddress(model.From),
            Subject = model.Subject,
            Body = model.Body,
        };
    }
}
