using System;

namespace ShoppingBasket.Model
{
    public class Rule : RuleEngine.Rule
    {
        public int Id { get; }
        public Product SourceProduct { get; }
        public Rule(int id, Product sourceProduct, string memberName, string method, string targetValue) : base(memberName, method, targetValue)
        {
            Id = id;
            SourceProduct = sourceProduct;
        }
    }
}