using System.Collections.Generic;

namespace ShoppingBasket.Repositories
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetFromSource()
        {
            return new List<Product>
            {
                new Product(0, "Butter", 0.8),
                new Product(1, "Milk", 1.15),
                new Product(2, "Bread", 1.00)
            };
        }
    }
}