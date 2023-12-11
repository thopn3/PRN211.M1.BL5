using Microsoft.AspNetCore.Mvc;

namespace Topic1_Basic_ASP_NETCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
