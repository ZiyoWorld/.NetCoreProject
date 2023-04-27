using Microsoft.AspNetCore.Mvc;

namespace Houzing2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
