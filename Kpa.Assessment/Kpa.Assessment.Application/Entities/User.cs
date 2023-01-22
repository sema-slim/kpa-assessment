namespace Kpa.Assessment.Application.Entities;

public class User
{
    public int UserId { get; }
    public string UserName { get; }

    public User(int userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }
}