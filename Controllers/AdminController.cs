using Microsoft.AspNetCore.Mvc;

namespace Shawpnojatra_Foundation.Controllers
{
	public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("admin");
        }

        public IActionResult Message()
        {
            return View("messages");
        }
    }
}
