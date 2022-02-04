using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fish.Models;

namespace Fish.Controllers;
[Area("Admin")]
[BasicAuthorize]
public class HomeController : Controller
{
    // GET: /Home/
    public IActionResult Index()
    {
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

