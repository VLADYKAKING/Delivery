using Delivery.Interfaces;
using Delivery.Models;

namespace Delivery.Repository
{
    public class CategoryRepository : ICategories
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> GetCategories => appDBContent.Category;
    }
}
