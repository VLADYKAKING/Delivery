using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Контакты";
            return View();
        }
    }
}
