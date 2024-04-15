using Microsoft.AspNetCore.Mvc;

public class MainController : Controller
{
    [Route("")]
    [Route("Index")]
    public IActionResult Index() => View();
    [Route("Second")]
    public IActionResult Second() => View();
}