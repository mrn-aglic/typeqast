using System;
using ShoppingBasket.Model;

namespace ShoppingBasket.RuleCompiler
{
    public class CompilerResult
    {
        public Product SourceProduct { get; }
        public Product TargetProduct { get; }
        public int RequiredAmount { get; }
        public Func<BasketItem, bool> CompiledRule { get; }
        public Func<Product, double> CompiledDiscount { get; }

        public CompilerResult(Product sourceProduct, Product targetProduct, int requiredAmount,
            Func<BasketItem, bool> compiledRule, Func<Product, double> compiledDiscount)
        {
            SourceProduct = sourceProduct;
            TargetProduct = targetProduct;
            RequiredAmount = requiredAmount;
            CompiledRule = compiledRule;
            CompiledDiscount = compiledDiscount;
        }
    }
}