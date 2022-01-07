using Delivery.Interfaces;
using Delivery.Models;
using Delivery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class CartController : Controller
    {
        private readonly IFood _foodRepos;
        private readonly Cart _cart;
        public CartController(IFood foodRepos, Cart cart)
        {
            _foodRepos = foodRepos;
            _cart = cart;
        }
        public ViewResult Index()
        {
            var items = _cart.getShopItems();
            _cart.listItems = items;

            int sum=0;
            foreach( CartItem el in items)
            {
                sum += el.price;
            }

            var obj = new CartViewModel
            {
                cart = _cart,
                summ = sum
            };
            ViewBag.Title = "Корзина";
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _foodRepos.GetFood.FirstOrDefault(i => i.id == id);

            if (item != null)
            {
                _cart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult deleteFromCart(int id)
        {
            _cart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
