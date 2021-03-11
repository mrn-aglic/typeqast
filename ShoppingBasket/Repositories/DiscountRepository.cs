using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Model;
using DbDiscount = ShoppingBasket.DbModel.Discount;

namespace ShoppingBasket.Repositories
{
    public class DiscountRepository : IRepository<Discount>
    {
        public RuleRepository RuleRepository { get; }
        public ProductRepository ProductRepository { get; }

        public DiscountRepository(RuleRepository ruleRepository, ProductRepository productRepository)
        {
            RuleRepository = ruleRepository;
            ProductRepository = productRepository;
        }

        public IEnumerable<DbDiscount> Table = new List<DbDiscount>
        {
            new DbDiscount(0, 0, 2, "Price", "Multiply", "0.5"),
            new DbDiscount(1, 1, 1, "Price", "Multiply", "1")
        };

        public IEnumerable<Discount> GetFromSource()
        {
            var products = ProductRepository.GetFromSource();

            var rules = RuleRepository.GetFromSource();
            return Table.Select(d =>
                new Model.Discount(
                    rules.First(r => r.Id == d.RuleId),
                    products.First(p => p.Id == d.TargetProductId),
                    d.MemberName,
                    d.Method,
                    d.TargetValue
                ));
        }
    }
}