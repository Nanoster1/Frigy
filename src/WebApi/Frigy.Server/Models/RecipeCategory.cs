using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class RecipeCategory : EntityBase
{
    private RecipeCategory() { }

    public RecipeCategory(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = null!;
}