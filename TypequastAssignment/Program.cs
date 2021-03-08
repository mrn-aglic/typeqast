using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShoppingBasket;
using ShoppingBasket.Repositories;
using ShoppingBasket.RuleEngine;

namespace TypequastAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductRepository().GetFromSource();

            var rules = new List<Rule>
            {
                new Rule("Num", "GreaterThanOrEqual", "2"),
                new Rule("Num", "GreaterThan", "3")
            };

            var basketItems = products.Select(x => new BasketItem(2, x));

            // var basket = new Basket();
            //
            // basket.AddProducts(basketItems);

            IRuleEngine ruleEngine = new RuleEngine();
            Console.WriteLine(ruleEngine.Compile<BasketItem, bool>(rules[0]));
        }
    }
}