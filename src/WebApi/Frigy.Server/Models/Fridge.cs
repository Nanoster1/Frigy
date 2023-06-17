using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class Fridge : EntityBase
{
    private Fridge() { }

    public Fridge(string name, int userId)
    {
        Name = name;
        UserId = userId;
        Products = new();
    }

    public string Name { get; set; } = null!;
    public int UserId { get; set; }
    public List<ProductInFridge> Products { get; set; } = null!;
}