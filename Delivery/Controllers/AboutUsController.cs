using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "О нас";
            return View();
        }
    }
}
