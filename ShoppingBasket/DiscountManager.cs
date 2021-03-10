using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Repositories;
using ShoppingBasket.RuleCompiler;
using RlCompiler = ShoppingBasket.Compiler.RuleCompiler;

namespace ShoppingBasket
{
    public class DiscountManager
    {
        private readonly IEnumerable<CompilerResult> _compilerResults;

        public DiscountManager(RlCompiler ruleCompiler, DiscountRepository discountRepository)
        {
            var discounts = discountRepository.GetFromSource();
            _compilerResults = ruleCompiler.Compile(discounts);
        }

        public IEnumerable<DiscountResult> GetDiscountResults(Dictionary<int, BasketItem> basketItems)
        {
            List<DiscountResult> discountResults = new List<DiscountResult>();

            foreach (var (productId, basketItem) in basketItems)
            {
                var results = _compilerResults.Where(cr => cr.SourceProduct.Id == productId);

                foreach (var compilerResult in results)
                {
                    if (!compilerResult.CompiledRule(basketItem)) continue;

                    var repeat = basketItem.Num / compilerResult.RequiredAmount;
                    var amount = compilerResult.CompiledDiscount(compilerResult.TargetProduct);

                    var repeats = Enumerable.Repeat(compilerResult.RequiredAmount, repeat).ToArray();
                    
                    repeats[repeats.Length - 1] =
                        basketItem.Num - (repeat - 1) * compilerResult.RequiredAmount;
                    
                    // repeats[^1] =
                    //     basketItem.Num - (repeat - 1) * compilerResult.RequiredAmount;

                    discountResults.AddRange(repeats.Select(reasonNum =>
                        new DiscountResult(basketItem, reasonNum, compilerResult.TargetProduct, amount)));

                    // for (var i = 0; i < repeat; i++)
                    // {
                    //     discountResults.Add(new DiscountResult
                    //         (
                    //             basketItem.Copy(basketItem.Num),
                    //             compilerResult.TargetProduct,
                    //             amount
                    //         )
                    //     );
                    // }
                }
            }

            return discountResults;
        }

        // public IEnumerable<DiscountResult> ApplyDiscounts(Dictionary<int, BasketItem> basketItems)
        // {
        //     List<DiscountResult> discountResults = new List<DiscountResult>();
        //
        //     foreach (var (productId, basketItem) in basketItems)
        //     {
        //         var rules = _compiledRules.Where(cr => cr.SourceProductId == productId);
        //         var discount = _compiledDiscounts.Single(d => d.SourceProductId == productId);
        //         foreach (var compiledRule in rules)
        //         {
        //             if (compiledRule.Rule(basketItem))
        //             {
        //                 var product = basketItems[discount.TargetProductId].Product;
        //                 var amount = discount.GetDiscount(product);
        //
        //                 discountResults.Add(new DiscountResult(basketItem, product, amount));
        //             }
        //         }
        //     }
        //
        //     return discountResults;
        // }
    }
}