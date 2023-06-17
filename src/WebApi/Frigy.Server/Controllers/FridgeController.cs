using Frigy.Server.Controllers.Common;
using Frigy.Server.Data;
using Frigy.Server.Models;

using Microsoft.AspNetCore.Mvc;

namespace Frigy.Server.Controllers;

[Route("api/[controller]")]
public class FridgeController : ApiController
{
    private readonly FrigyContext _context;

    public FridgeController(FrigyContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ActionResult<IEnumerable<Product>> GetAllProductsFromFridge()
    {
        return Ok(_context.Fridges.First().Products.ToList());
    }

    [HttpGet("important/missing")]
    public ActionResult<IEnumerable<Product>> GetMissingImportantProducts()
    {
        return Ok(_context.Fridges.First().Products.Where(p => p.IsImportant && p.Quantity < p.MinimalQuantity));
    }

    [HttpPost]
    public ActionResult AddProduct(ProductInFridge product)
    {
        _context.Fridges.First().Products.Add(product);
        _context.SaveChanges();
        return Ok();
    }
}