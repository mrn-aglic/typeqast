namespace ShoppingBasket.RuleEngine
{
    public class Rule
    {
        public string MemberName { get; }

        public string Method { get; }
        public string TargetValue { get; }

        public Rule(string memberName, string method, string targetValue)
        {
            MemberName = memberName;
            Method = method;
            TargetValue = targetValue;
        }
    }
}