using Delivery.Models;

namespace Delivery.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
