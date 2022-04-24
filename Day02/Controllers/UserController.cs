using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
