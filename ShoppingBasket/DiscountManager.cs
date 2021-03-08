using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.DbModel;
using ShoppingBasket.Repositories;
using ShoppingBasket.RuleEngine;

namespace ShoppingBasket
{
    public class DiscountManager : RuleEngine.RuleEngine
    {
        private readonly IEnumerable<CompiledRule> _compiledRules;
        private IEnumerable<CompiledDiscount> _compiledDiscounts;

        public DiscountManager(RuleRepository rulesRepository, DiscountRepository discountRepository)
        {
            _compiledRules = rulesRepository.GetFromSource()
                .Select(r => new CompiledRule(r.SourceProductId, Compile<BasketItem, bool>(r)));

            _compiledDiscounts = discountRepository.GetFromSource()
                .Cast<DiscountRule>()
                .Select(d =>
                    new CompiledDiscount(d.SourceProductId, d.TargetProductId, Compile<Product, double>(d)));
        }

        // public IEnumerable<CompiledRule> CompileRules(IRuleRepository ruleRepository)
        // {
        //     var rules = ruleRepository.GetFromSource();
        //     return rules.Select(r => new CompiledRule(r.SourceProductId, Compile<BasketItem>(r)));
        // }

        public IEnumerable<DiscountResult> ApplyDiscounts(Dictionary<int, BasketItem> basketItems)
        {
            List<DiscountResult> discountResults = new List<DiscountResult>();

            foreach (var (productId, basketItem) in basketItems)
            {
                var rules = _compiledRules.Where(cr => cr.SourceProductId == productId);
                var discount = _compiledDiscounts.Single(d => d.SourceProductId == productId);
                foreach (var compiledRule in rules)
                {
                    if (compiledRule.Rule(basketItem))
                    {
                        var product = basketItems[discount.TargetProductId].Product;
                        var amount = discount.GetDiscount(product);

                        discountResults.Add(new DiscountResult(basketItem, product, amount));
                    }
                }
            }

            return discountResults;
        }
    }
}