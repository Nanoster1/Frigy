using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class ProductCategory : EntityBase
{
    private ProductCategory() { }

    public ProductCategory(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = null!;
}