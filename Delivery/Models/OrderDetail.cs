namespace Delivery.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int foodId { get; set; }
        public uint price { get; set; }
        public virtual Food food { get; set; }
        public virtual Order order { get; set; }
    }
}
