using Frigy.Server.Models.Common.Base;

namespace Frigy.Server.Models;

public class Product : EntityBase
{
    public Product(string title, int productCategory, bool isImportant, int count, int maxCount)
    {
        Title = title;
        ProductCategory = productCategory;
        IsImportant = isImportant;
        Count = count;
        MaxCount = maxCount;
    }

    protected Product() { }

    public string Title { get; set; } = null!;
    public int ProductCategory { get; set; }
    public bool IsImportant { get; set; }
    public int Count { get; set; }
    public int MaxCount { get; set; }
}