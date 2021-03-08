using System;

namespace ShoppingBasket
{
    public class CompiledDiscount
    {
        public int SourceProductId { get; }
        public int TargetProductId { get; }
        public Func<Product, double> GetDiscount { get; }

        public CompiledDiscount(int sourceProductId, int targetProductId, Func<Product, double> getDiscount)
        {
            SourceProductId = sourceProductId;
            TargetProductId = targetProductId;
            GetDiscount = getDiscount;
        }
    }
}