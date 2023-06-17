using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class ProductType : EntityBase
{
    private ProductType() { }

    public ProductType(string name, ProductCategory category)
    {
        Name = name;
        Category = category;
    }

    public string Name { get; set; } = null!;
    public ProductCategory Category { get; set; } = null!;
}