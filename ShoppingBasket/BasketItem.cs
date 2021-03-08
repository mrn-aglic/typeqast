namespace ShoppingBasket
{
    public class BasketItem
    {
        public int Num { get; }
        public Product Product { get; }

        public BasketItem(int num, Product product)
        {
            Num = num;
            Product = product;
        }

        public BasketItem AddQuantity(int num)
        {
            return new(Num + num, Product);
        }

        public double GetPrice()
        {
            return Num * Product.Price;
        }
    }
}