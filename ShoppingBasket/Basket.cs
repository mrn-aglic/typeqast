using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.RuleEngine;

namespace ShoppingBasket
{
    public class Basket
    {
        private DiscountManager _discountManager;
        private readonly Dictionary<int, BasketItem> _accumulatedBasketItems;

        public Basket(DiscountManager discountManager)
        {
            _discountManager = discountManager;
            _accumulatedBasketItems = new Dictionary<int, BasketItem>();
        }

        public double CalculateSum()
        {
            var sum = 0.0;
            foreach (var (productId, basketItem) in _accumulatedBasketItems)
            {
                sum += basketItem.GetPrice();
            }

            foreach (var discountResult in _discountManager.GetDiscountResults(_accumulatedBasketItems))
            {
                Console.WriteLine(discountResult.GetDescription());
                sum -= discountResult.Amount;
            }

            return Math.Round(sum, 3);
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

        public void AddProducts(params BasketItem[] items)
        {
            AddProducts(items.ToList());
        }

        public void Clear()
        {
            _accumulatedBasketItems.Clear();
        }
    }
}