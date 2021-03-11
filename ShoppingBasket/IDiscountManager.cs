using System.Collections.Generic;

namespace ShoppingBasket
{
    public interface IDiscountManager
    {
        public IEnumerable<DiscountResult> GetDiscountResults(Dictionary<int, BasketItem> basketItems);
    }
}