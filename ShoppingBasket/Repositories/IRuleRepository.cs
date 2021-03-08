using System.Collections.Generic;
using ShoppingBasket.DbModel;
using ShoppingBasket.RuleEngine;

namespace ShoppingBasket.Repositories
{
    public interface IRuleRepository
    {
        public IEnumerable<RuleRecord> GetFromSource();
    }
}