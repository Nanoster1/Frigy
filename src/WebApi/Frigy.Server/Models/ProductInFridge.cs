namespace Frigy.Server.Models;

public class ProductInFridge : Product
{
    private ProductInFridge() { }

    public ProductInFridge(
        ProductType type,
        double quantity,
        bool isImportant,
        double minimalQuantity) : base(type, quantity)
    {
        IsImportant = isImportant;
        MinimalQuantity = minimalQuantity;
    }

    public bool IsImportant { get; set; }
    public double MinimalQuantity { get; set; }

}