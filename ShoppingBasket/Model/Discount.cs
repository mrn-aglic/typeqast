namespace ShoppingBasket.Model
{
    public class Discount : RuleEngine.Rule
    {
        public Rule Rule { get; }
        public Product TargetProduct { get; }

        public Discount(Rule rule, Product targetProduct, string memberName, string method, string targetValue)
            : base(memberName, method, targetValue)
        {
            Rule = rule;
            TargetProduct = targetProduct;
        }
    }
}