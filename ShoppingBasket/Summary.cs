using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Summary
    {
        public double Total { get; }
        public IEnumerable<DiscountResult> Discounts { get; }
        public IEnumerable<BasketItem> Items { get; }

        public Summary(double total, IEnumerable<DiscountResult> discounts, IEnumerable<BasketItem> items)
        {
            Total = total;
            Discounts = discounts;
            Items = items;
        }

        public override string ToString()
        {
            var header = "List of items in basket:\n";
            var itemsMsg = Items.Aggregate(header,
                (x, y) => $"{x}{y.Product.Name}: {y.Num}, price: {y.GetPrice()} ({y.Product.Price} per unit)\n");
            var msg = Discounts.Aggregate("", (x, y) => $"{x}{y.GetDescription()}\n");
            var total = $"Total amount: {Total}\n";
            return Discounts.Any() ? $"{itemsMsg}\n{msg}\n{total}" : total;
        }
    }
}