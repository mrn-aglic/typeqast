using System;
using System.Collections;
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

        public Summary CalculateSum()
        {
            var sum = 0.0;
            foreach (var (_, basketItem) in _accumulatedBasketItems)
            {
                sum += basketItem.GetPrice();
            }

            var discountResults = _discountManager.GetDiscountResults(_accumulatedBasketItems).ToArray();
            foreach (var discountResult in discountResults)
            {
                sum -= discountResult.Amount;
            }

            return new Summary(Math.Round(sum, 3), discountResults, _accumulatedBasketItems.Select(acc => acc.Value));
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