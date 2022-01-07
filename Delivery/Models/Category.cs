namespace Delivery.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public List<Food> food { get; set; }
    }
}
