namespace Delivery.Models
{
    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isPopular { get; set; }
        public int categoryId { get; set; }
        public virtual Category category { get; set; }
    }
}
