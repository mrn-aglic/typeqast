namespace ShoppingBasket.DbModel
{
    public class Discount
    {
        public int Id { get; set; }
        public int RuleId { get; set; }
        public int TargetProductId { get; set; }

        public string MemberName { get; set; }
        public string Method { get; set; }
        public string TargetValue { get; set; }

        public Discount(int id, int ruleId, int targetProductId, string memberName, string method, string targetValue)
        {
            Id = id;
            RuleId = ruleId;
            TargetProductId = targetProductId;
            MemberName = memberName;
            Method = method;
            TargetValue = targetValue;
        }
    }
}