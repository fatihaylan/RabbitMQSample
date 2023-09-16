using BookApi.Books;
using BookApi.Users;
using RabbitMQ.Models;
using RabbitMQ.Services;

namespace BookApi.Extensions;

public static class MailModelExtensions
{
    public static IEnumerable<MailModel> GetNewBookMails(this BookDto book)
    {
        var mails = new List<MailModel>();
        string subject = $"New Book on our shelves!";
        string body = $"{book.Title} is now on our shelves!";
        var userMails = UserExtensions.GetUsers().Select(x => x.Email);

        foreach (var userMail in userMails)
        {
            mails.Add(new MailModel()
            {
                Subject = subject,
                Body = body,
                To = userMail,
            });
        }
        return mails;
    }
}