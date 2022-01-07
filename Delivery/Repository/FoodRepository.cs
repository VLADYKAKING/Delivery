using Delivery.Interfaces;
using Delivery.Models;
using System.Data.Entity;

namespace Delivery.Repository
{
    public class FoodRepository : IFood
    {
        private readonly AppDBContent appDBContent;
        public FoodRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Food> GetFood => appDBContent.Food.Include(c => c.category);

        public IEnumerable<Food> GetPopularFood => appDBContent.Food.Where(p => p.isPopular).Include(c => c.category);

        public Food getObjectFood(int foodId) => appDBContent.Food.FirstOrDefault(p => p.id == foodId);

    }
}
