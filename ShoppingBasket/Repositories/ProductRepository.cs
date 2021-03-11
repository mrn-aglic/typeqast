using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Model;
using DbProduct = ShoppingBasket.DbModel.Product;

namespace ShoppingBasket.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public IEnumerable<DbProduct> Table = new List<DbProduct>
        {
            new DbProduct(0, "Butter", 0.8),
            new DbProduct(1, "Milk", 1.15),
            new DbProduct(2, "Bread", 1.00)
        };

        public IEnumerable<Product> GetFromSource()
        {
            return Table.Select(p => new Product(p.Id, p.Name, p.Price));
        }
    }
}