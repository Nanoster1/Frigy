using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Frigy.Server.Controllers.Common;
using Frigy.Server.Data;
using Frigy.Server.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace Frigy.Server.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class AuthenticationController : ApiController
{
    public static readonly string Secret = string.Join(string.Empty, Enumerable.Range(1, 50));

    private readonly FrigyContext _context;

    public AuthenticationController(FrigyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<string> Login(string name, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);

        if (user is null) return BadRequest();

        var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
            new Claim(JwtClaimTypes.Name, user.Name)
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    [HttpPost]
    public ActionResult<string> Register(string name, string password)
    {
        if (_context.Users.Any(u => u.Name == name))
            return BadRequest();

        var user = new User(name, password);
        _context.Users.Add(user);

        var fridge = new Fridge(user.Name, user.Id);
        _context.Fridges.Add(fridge);

        var shoppingList = new ShoppingList(user.Id);
        _context.ShoppingLists.Add(shoppingList);

        _context.SaveChanges();

        var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
            new Claim(JwtClaimTypes.Name, user.Name)
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}