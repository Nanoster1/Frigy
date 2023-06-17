using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class Product : EntityBase
{
    protected Product() { }

    public Product(ProductType type, double quantity)
    {
        Type = type;
        Quantity = quantity;
    }

    public ProductType Type { get; set; } = null!;
    public double Quantity { get; set; }
}