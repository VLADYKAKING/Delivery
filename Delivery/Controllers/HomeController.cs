using Delivery.Interfaces;
using Delivery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFood _foodRepos;
        public HomeController(IFood foodRepos)
        {
            _foodRepos = foodRepos;
        }
        public ViewResult Index()
        {
            var homeFood = new HomeViewModel
            {
                popularFood = _foodRepos.GetPopularFood
            };
            ViewBag.Title = "Delivery";
            return View(homeFood);
        }
    }
}
