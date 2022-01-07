using Delivery.Models;

namespace Delivery.Interfaces
{
    public interface IFood
    {
        IEnumerable<Food> GetFood { get; }
        IEnumerable<Food> GetPopularFood { get; }
        Food getObjectFood(int foodId);
    }
}
