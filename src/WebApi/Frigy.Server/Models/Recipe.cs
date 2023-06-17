using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class Recipe : EntityBase
{
    private Recipe() { }

    public Recipe(string name, int userId, RecipeCategory category)
    {
        Name = name;
        UserId = userId;
        Category = category;
        Products = new();
    }

    public string Name { get; set; } = null!;
    public int UserId { get; set; }
    public RecipeCategory Category { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
}