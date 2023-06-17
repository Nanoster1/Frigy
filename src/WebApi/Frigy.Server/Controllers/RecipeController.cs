using Frigy.Server.Controllers.Common;
using Frigy.Server.Data;
using Frigy.Server.Models;

using Microsoft.AspNetCore.Mvc;

namespace Frigy.Server.Controllers;

[Route("/api/[controller]")]
public class RecipeController : ApiController
{
    private readonly FrigyContext _context;

    public RecipeController(FrigyContext context)
    {
        _context = context;
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<Recipe>> GetAll()
    {
        return Ok(_context.Recipes);
    }
}