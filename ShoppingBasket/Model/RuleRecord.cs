using System;

namespace ShoppingBasket.Model
{
    public class Rule : Compiled<BasketItem, bool>
    {
        public Product SourceProduct { get; }

        public Rule(Product sourceProduct, Func<BasketItem, bool> method) : base(method)
        {
            SourceProduct = sourceProduct;
        }
    }
}