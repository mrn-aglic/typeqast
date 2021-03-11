using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Model;
using DbRule = ShoppingBasket.DbModel.Rule;

namespace ShoppingBasket.Repositories
{
    public class RuleRepository : IRepository<Rule>
    {
        public ProductRepository ProductRepository { get; }

        public RuleRepository(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IEnumerable<DbRule> Table = new List<DbRule>
        {
            new DbRule(0, 0, "Num", "GreaterThanOrEqual", "2"),
            new DbRule(1, 1, "Num", "GreaterThanOrEqual", "4")
        };

        public IEnumerable<Rule> GetFromSource()
        {
            var products = ProductRepository.GetFromSource();
            return Table.Select(r =>
                new Rule
                (
                    r.Id,
                    products.First(p => p.Id == r.SourceProductId),
                    r.MemberName,
                    r.Method,
                    r.TargetValue
                ));
        }
    }
}