using Microsoft.AspNetCore.Mvc;

namespace TreeSharp.Controllers;

[ApiController]
[Route("api")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Home() => Ok();
}