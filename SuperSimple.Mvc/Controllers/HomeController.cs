using Microsoft.AspNetCore.Mvc;

namespace SuperSimple.Mvc.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
