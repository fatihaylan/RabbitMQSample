using BookApi.Books;
using BookApi.Users;
using RabbitMQ.Models;
using RabbitMQ.Services;

namespace BookApi.Extensions;

public static class MailModelExtensions
{
    public static IEnumerable<MailModel> GetNewBookMails(this BookDto book, ISmtpConfiguration smtpConfiguration)
    {
        var mails = new List<MailModel>();
        string subject = $"New Book on our shelves!";
        string body = $"{book.Title} is now on our shelves!";
        var toUsers = UserExtensions.GetUsers();

        foreach (var user in toUsers)
        {
            mails.Add(new MailModel()
            {
                Subject = subject,
                Body = body,
                From = smtpConfiguration.User,
                To = user.Email,
            });
        }
        return mails;
    }
}