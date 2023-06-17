using Frigy.Server.Controllers.Common;
using Frigy.Server.Data;

using Microsoft.AspNetCore.Mvc;

namespace Frigy.Server.Controllers;

[Route("api/[controller]")]
public class ShoppingListController : ApiController
{
    private readonly FrigyContext _context;

    public ShoppingListController(FrigyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult AddMissingImportantProducts()
    {
        var missingImportantProducts = _context.Fridges
            .First()
            .Products
            .Where(p => p.IsImportant && p.Quantity < p.MinimalQuantity);

        _context.ShoppingLists.First().Products.AddRange(missingImportantProducts);
        _context.SaveChanges();

        return Ok();
    }
}