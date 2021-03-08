using System.Collections.Generic;
using ShoppingBasket.DbModel;

namespace ShoppingBasket.Repositories
{
    public class DiscountRepository : IRuleRepository
    {
        public IEnumerable<RuleRecord> GetFromSource()
        {
            return new List<DiscountRule>
            {
                new DiscountRule(0, 2, "Price", "Multiply", "0.5"),
                new DiscountRule(1, 1, "Price", "Multiply", "1")
            };
        }

        // public IEnumerable<Discount> GetFromSource2()
        // {
        //     return new List<Discount>
        //     {
        //         new Discount(0, 2, product => product.Price / 2),
        //         new Discount(1, 1, product => product.Price / 4)
        //     };
        // }
    }
}