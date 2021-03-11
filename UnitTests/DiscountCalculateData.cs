using System.Collections;
using ShoppingBasket;
using ShoppingBasket.Model;

namespace UnitTests
{
    public class DiscountCalculateData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var butter = new Product(0, "butter", 0.8);
            var milk = new Product(1, "milk", 1.15);
            var bread = new Product(2, "bread", 1.00);
            yield return new object[]
                {2.95, new[] {new BasketItem(1, butter), new BasketItem(1, milk), new BasketItem(1, bread)}};
            yield return new object[]
                {3.10, new[] {new BasketItem(2, butter), new BasketItem(0, milk), new BasketItem(2, bread)}};
            yield return new object[]
                {3.45, new[] {new BasketItem(0, butter), new BasketItem(4, milk), new BasketItem(0, bread)}};
            yield return new object[]
                {9.00, new[] {new BasketItem(2, butter), new BasketItem(8, milk), new BasketItem(1, bread)}};
            yield return new object[]
                {10.15, new[] {new BasketItem(2, butter), new BasketItem(9, milk), new BasketItem(1, bread)}};
        }
    }
}