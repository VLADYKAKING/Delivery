namespace Delivery.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public Food food { get; set; }
        public int price { get; set; }
        public string CartId { get; set; }
    }
}
