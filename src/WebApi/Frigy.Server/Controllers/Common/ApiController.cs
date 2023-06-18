using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frigy.Server.Controllers.Common;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected int UserId => int.Parse(
        User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
}