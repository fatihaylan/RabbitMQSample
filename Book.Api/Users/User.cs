namespace BookApi.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}

public static class UserExtensions
{
    public static List<User> GetUsers()
    {
        return new List<User>
        {
            new User { Id = 0, Name = "Fatih", Surname = "Aylan", Email = "aylan34@gmail.com" }
        };

    }
}