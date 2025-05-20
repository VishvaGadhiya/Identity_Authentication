using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
