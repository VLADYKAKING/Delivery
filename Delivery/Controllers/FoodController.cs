using Delivery.Interfaces;
using Delivery.Models;
using Delivery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFood _food;
        private readonly ICategories _categories;

        public FoodController(IFood ifood, ICategories icategories)
        {
            _food = ifood;
            _categories = icategories;
        }

        [Route("Food/List")]
        [Route("Food/List/{category}")]

        public ViewResult List(string category)
        {
            IEnumerable<Food> food = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                food = _food.GetFood.OrderBy(i => i.id);
                currentCategory = "Меню";
            }
            else
            {
                if (string.Equals("pizza", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _food.GetFood.Where(i => i.categoryId == 1).OrderBy(i => i.name);
                    currentCategory = "Пицца";
                }
                else if (string.Equals("sushi", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _food.GetFood.Where(i => i.categoryId == 2).OrderBy(i => i.name);
                    currentCategory = "Суши/Роллы";
                }
                else if (string.Equals("meat", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _food.GetFood.Where(i => i.categoryId == 3).OrderBy(i => i.name);
                    currentCategory = "Мясо";
                }
            }
            var foodObject = new FoodListViewModel
            {
                allFood = food,
                currentCategory = currentCategory
            };
            ViewBag.Title = currentCategory;
            return View(foodObject);
        }
    }
}
