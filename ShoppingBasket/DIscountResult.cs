namespace ShoppingBasket
{
    public class DiscountResult
    {
        public BasketItem Source { get; }
        public Product Target { get; }
        public double Amount { get; }

        public DiscountResult(BasketItem source, Product target, double amount)
        {
            Source = source;
            Target = target;
            Amount = amount;
        }

        public string GetDescription()
        {
            return
                $"Discount applied for: {Source.Product.Name} because of quantity {Source.Num} on item {Target.Name} " +
                $"with amount: {Amount}";
        }
    }
}