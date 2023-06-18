namespace Frigy.Server.Models;

public class ProductToBuy : Product
{
    private ProductToBuy() { }

    public ProductToBuy(
        string title,
        int productCategory,
        bool isImportant,
        int count,
        int maxCount,
        bool isBuy) :
        base(title, productCategory, isImportant, count, maxCount)
    {
        IsBuy = isBuy;
    }

    public bool IsBuy { get; set; }
}