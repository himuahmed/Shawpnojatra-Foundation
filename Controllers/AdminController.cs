using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shawpnojatra_Foundation.Controllers
{
    [Authorize]
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

        public IActionResult WebSiteLink()
		{
            return View();
		}
    }
}
