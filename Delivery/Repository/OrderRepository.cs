using Delivery.Interfaces;
using Delivery.Models;

namespace Delivery.Repository
{
    public class OrderRepository : IOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly Cart cart;
        public OrderRepository(AppDBContent appDBContent, Cart cart)
        {
            this.appDBContent = appDBContent;
            this.cart = cart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = cart.listItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    orderId = order.id,
                    foodId = el.food.id,
                    price = el.food.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
