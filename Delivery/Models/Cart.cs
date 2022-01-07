using Microsoft.EntityFrameworkCore;

namespace Delivery.Models
{
    public class Cart
    {
        private readonly AppDBContent appDBContent;
        public Cart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string cartId { get; set; }
        public List<CartItem> listItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string currCartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();

            session.SetString("cartId", currCartId);

            return new Cart(context) { cartId = currCartId };
        }
        public void AddToCart(Food food)
        {
            appDBContent.CartItem.Add(new CartItem
            {
                CartId = cartId,
                food = food,
                price = food.price
            });

            appDBContent.SaveChanges();
        }
        //public void ClearCart()
        //{
        //    appDBContent.Remove(appDBContent.CartItem.Where(c => c.CartId == cartId));
        //    appDBContent.SaveChanges();
        //}
        public void ClearCart()
        {
            var items = appDBContent.CartItem.Where(c => c.CartId == cartId);
            foreach(var el in items)
            {
                appDBContent.CartItem.Remove(el);
            }
            appDBContent.SaveChanges();
        }
        public List<CartItem> getShopItems()
        {
            return appDBContent.CartItem.Where(c => c.CartId == cartId).Include(s => s.food).ToList();
        }
    }
}
