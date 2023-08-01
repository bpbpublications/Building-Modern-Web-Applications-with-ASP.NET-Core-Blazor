using Microsoft.AspNetCore.Mvc;

namespace EShop.Server.Controllers;

[Route("hello")]
public class HelloControler : ControllerBase
{
    [HttpGet]
    public IActionResult SayHi()
    {
        return Content("Hello, world! From Controller.");
    }
}