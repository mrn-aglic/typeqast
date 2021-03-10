namespace ShoppingBasket.DbModel
{
    public class Rule
    {
        public int Id { get; }
        public int SourceProductId { get; }
        public string MemberName { get; }
        public string Method { get; }
        public string TargetValue { get; }
        

        public Rule(int id, int sourceProductId, string memberName, string method, string targetValue)
        {
            Id = id;
            SourceProductId = sourceProductId;
            MemberName = memberName;
            Method = method;
            TargetValue = targetValue;
        }
    }
}