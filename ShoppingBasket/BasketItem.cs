using ShoppingBasket.Model;

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

        public BasketItem Copy(int newNum)
        {
            return new(newNum, Product);
        }

        public BasketItem Copy()
        {
            return Copy(Num);
        }

        public double GetPrice()
        {
            return Num * Product.Price;
        }
    }
}