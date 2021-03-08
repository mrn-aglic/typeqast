namespace ShoppingBasket.DbModel
{
    public class DiscountRule : RuleRecord
    {
        public int TargetProductId { get; }

        public DiscountRule(int sourceProductId, int targetProductId, string memberName, string method,
            string targetValue) : base(sourceProductId, memberName, method, targetValue)
        {
            TargetProductId = targetProductId;
        }
    }
}