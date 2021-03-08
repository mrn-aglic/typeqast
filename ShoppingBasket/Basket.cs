using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.RuleEngine;

namespace ShoppingBasket
{
    public class Basket
    {
        private readonly Dictionary<int, BasketItem> _accumulatedBasketItems;

        public Basket(DiscountManager discountManager)
        {
            _accumulatedBasketItems = new Dictionary<int, BasketItem>();
        }

        public double CalculateSum()
        {
            var sum = 0.0;
            foreach (var (productId, basketItem) in _accumulatedBasketItems)
            {
                sum += basketItem.GetPrice();
            }
            return sum;
        }

        public void Add(BasketItem basketItem)
        {
            if (_accumulatedBasketItems.ContainsKey(basketItem.Product.Id))
            {
                _accumulatedBasketItems[basketItem.Product.Id] = basketItem.AddQuantity(basketItem.Num);
            }
            else
            {
                _accumulatedBasketItems.Add(basketItem.Product.Id, basketItem);
            }
        }

        public void AddProducts(IEnumerable<BasketItem> items)
        {
            items.ToList().ForEach(Add);
        }
    }
}