using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstApproach.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DashboardController : Controller
    {
       
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
