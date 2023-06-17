using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class User : EntityBase
{
    private User() { }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
}