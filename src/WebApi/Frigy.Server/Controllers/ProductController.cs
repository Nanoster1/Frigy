using Frigy.Server.Controllers.Common;
using Frigy.Server.Data;
using Frigy.Server.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frigy.Server.Controllers;

[Route("api/[controller]")]
public class ProductController : ApiController
{
    private readonly FrigyContext _context;

    public ProductController(FrigyContext context)
    {
        _context = context;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id, CancellationToken token)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, token);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet("all")]
    public ActionResult<IAsyncEnumerable<Product>> GetAll()
    {
        return Ok(_context.Products.AsAsyncEnumerable());
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] Product product, CancellationToken token)
    {
        await _context.Products.AddAsync(product, token);
        await _context.SaveChangesAsync(token);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut]
    public async Task<ActionResult<Product>> Update([FromBody] Product product, CancellationToken token)
    {
        _context.Update(product);
        await _context.SaveChangesAsync(token);
        return Ok(product);
    }
}