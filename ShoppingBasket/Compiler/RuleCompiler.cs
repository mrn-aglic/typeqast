using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Model;
using ShoppingBasket.RuleCompiler;

namespace ShoppingBasket.Compiler
{
    public class RuleCompiler : RuleEngine.RuleEngine
    {
        public CompilerResult Compile(Discount discount)
        {
            var compiledRule = Compile<BasketItem, bool>(discount.Rule);
            var compiledDiscount = Compile<Product, double>(discount);

            return new CompilerResult(discount.Rule.SourceProduct, discount.TargetProduct, int.Parse(discount.Rule.TargetValue), compiledRule,
                compiledDiscount);
        }

        public IEnumerable<CompilerResult> Compile(IEnumerable<Discount> discounts)
        {
            return discounts.Select(Compile);
        }
    }
}