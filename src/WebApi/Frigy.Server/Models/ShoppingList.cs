using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class ShoppingList : EntityBase
{
    private ShoppingList() { }

    public ShoppingList(int userId)
    {
        UserId = userId;
        Products = new();
    }

    public int UserId { get; set; }
    public List<Product> Products { get; set; } = null!;
}