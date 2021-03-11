using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Compiler;
using ShoppingBasket.Model;
using ShoppingBasket.Repositories;

namespace ShoppingBasket
{
    public class DiscountManager : IDiscountManager
    {
        private readonly IEnumerable<CompilerResult> _compilerResults;

        public DiscountManager(ICompiler ruleCompiler, IRepository<Discount> discountRepository)
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
                }
            }

            return discountResults;
        }
    }
}