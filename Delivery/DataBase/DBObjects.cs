using Delivery.Models;

namespace Delivery
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Food.Any())
            {
                content.AddRange
                (
                    new Food
                    {
                        name = "Филадельфия",
                        desc = "состав",
                        img = "/img/filad.jpg",
                        price = 999,
                        isPopular = true,
                        category = Categories["Суши/Роллы"]
                    }
                 );
            }
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { name = "Пицца", desc = "Традиционное итальянское блюдо в виде круглой дрожжевой лепёшки, выпекаемой с уложенной сверху начинкой из томатного соуса, сыра и зачастую других ингредиентов, таких как мясо, овощи, грибы и других продуктов." },
                        new Category { name = "Суши/Роллы", desc = "Блюдо традиционной японской кухни, приготовленное из риса с уксусной приправой и различных морепродуктов, а также других ингредиентов." }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.name, el);
                }
                return category;
            }
        }
    }
}
