using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Basket
    {
        private readonly IDiscountManager _discountManager;
        private readonly Dictionary<int, BasketItem> _accumulatedBasketItems;

        public Basket(IDiscountManager discountManager)
        {
            _discountManager = discountManager;
            _accumulatedBasketItems = new Dictionary<int, BasketItem>();
        }

        public Dictionary<int, BasketItem> GetCollectionCopy()
        {
            var dict = new Dictionary<int, BasketItem>();

            foreach (var (key, item) in _accumulatedBasketItems)
            {
                dict.Add(key, item.Copy());
            }
            
            return dict;
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