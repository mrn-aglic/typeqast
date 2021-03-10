using ShoppingBasket.Model;

namespace ShoppingBasket
{
    public class DiscountResult
    {
        public int ReasonNum { get; }
        public BasketItem Source { get; }
        public Product Target { get; }
        public double Amount { get; }

        public DiscountResult(BasketItem source, int reasonNum, Product target, double amount)
        {
            ReasonNum = reasonNum;
            Source = source;
            Target = target;
            Amount = amount;
        }

        public string GetDescription()
        {
            return
                $"Discount applied for: {Source.Product.Name} because of quantity {ReasonNum} (of {Source.Num}) on item {Target.Name} " +
                $"with amount: {Amount}";
        }
    }
}