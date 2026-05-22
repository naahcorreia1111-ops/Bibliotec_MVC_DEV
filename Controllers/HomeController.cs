using Microsoft.AspNetCore.Mvc;

namespace Bibliotec_MVC_DEV.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
