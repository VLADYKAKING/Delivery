using Delivery.Interfaces;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orders;
        private readonly Cart cart;
        public OrderController(IOrders orders, Cart cart)
        {
            this.orders = orders;
            this.cart = cart;
        }
        public IActionResult Form()
        {
            ViewBag.Title = "Заказ";
            return View();
        }
        [HttpPost]
        public IActionResult Form(Order order)
        {
            cart.listItems = cart.getShopItems();
            if (cart.listItems.Count == 0)
            {
                ModelState.AddModelError("", "Товары отсутствуют");
            }
            if (ModelState.IsValid)
            //else
            {
                orders.createOrder(order);
                return RedirectToAction("Success");
            }
            ViewBag.Title = "Заказ";
            return View(order);
        }
        public IActionResult Success()
        {
            ViewBag.Title = "Заказ завершен";
            ViewBag.Message = "Заказ отправлен";
            return View();
        }
    }
}
