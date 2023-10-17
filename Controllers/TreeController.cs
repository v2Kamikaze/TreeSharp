using Microsoft.AspNetCore.Mvc;
using TreeSharp.Services;

namespace TreeSharp.Controllers;

[ApiController]
[Route("api")]
public class TreeController : ControllerBase
{
    [HttpGet("v1/tree")] 
    public IActionResult Home([FromServices] TreeBuilderService treeService) {
        
        var node = treeService.BuildTree();

        return Ok(node);
    }
}