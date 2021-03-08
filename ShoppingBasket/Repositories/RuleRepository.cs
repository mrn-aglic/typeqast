using System.Collections.Generic;
using ShoppingBasket.DbModel;
using ShoppingBasket.RuleEngine;

namespace ShoppingBasket.Repositories
{
    public class RuleRepository : IRuleRepository
    {
        public IEnumerable<RuleRecord> GetFromSource()
        {
            return new List<RuleRecord>
            {
                new RuleRecord(0, "Num", "GreaterThanOrEqual", "2"),
                new RuleRecord(1, "Num", "GreaterThan", "3")
            };
        }
    }
}