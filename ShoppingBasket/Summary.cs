using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Summary
    {
        public double Total { get; }
        public IEnumerable<DiscountResult> Discounts { get; }

        public Summary(double total, IEnumerable<DiscountResult> discounts)
        {
            Total = total;
            Discounts = discounts;
        }

        public override string ToString()
        {
            var msg = Discounts.Aggregate("", (x, y) => $"{x}{y.GetDescription()}\n");
            var total = $"Total amount: {Total}\n";
            return Discounts.Any() ? $"{msg}\n{total}" : total;
        }
    }
}