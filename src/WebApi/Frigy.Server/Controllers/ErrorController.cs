using Frigy.Server.Controllers.Common;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frigy.Server.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class ErrorController : ApiController
{
    [HttpGet]
    public ActionResult Index()
    {
        return Problem();
    }
}