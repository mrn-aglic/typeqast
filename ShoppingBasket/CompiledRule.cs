using System;

namespace ShoppingBasket
{
    public class CompiledRule
    {
        public int SourceProductId { get; }
        public Func<BasketItem, bool> Rule { get; }
        public CompiledRule(int sourceProductId, Func<BasketItem, bool> rule)
        {
            SourceProductId = sourceProductId;
            Rule = rule;
        }
    }
}