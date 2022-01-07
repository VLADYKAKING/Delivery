using Delivery.Models;

namespace Delivery.ViewModels
{
    public class FoodListViewModel
    {
        public IEnumerable<Food> allFood { get; set; }
        public string currentCategory { get; set; }
    }
}
