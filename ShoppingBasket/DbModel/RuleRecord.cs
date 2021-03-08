using ShoppingBasket.RuleEngine;

namespace ShoppingBasket.DbModel
{
    public class RuleRecord : Rule
    {
        public int Id { get; }
        public int SourceProductId { get; }

        public RuleRecord(int id, int sourceProductId, string memberName, string method, string targetValue)
            : base(memberName, method, targetValue)
        {
            SourceProductId = sourceProductId;
        }
    }
}