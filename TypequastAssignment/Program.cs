using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket;
using ShoppingBasket.Compiler;
using ShoppingBasket.Model;
using ShoppingBasket.Repositories;
using ShoppingBasket.RuleEngine;
using Rule = ShoppingBasket.RuleEngine.Rule;

namespace TypequastAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var ruleRepository = new RuleRepository(productRepository);
            var discountRepository = new DiscountRepository(ruleRepository, productRepository);

            var discountManager = new DiscountManager(new RuleCompiler(), discountRepository);

            var basket = new Basket(discountManager);

            var products = productRepository.GetFromSource().ToArray();
            var butter = products[0];
            var milk = products[1];
            var bread = products[2];
            
            basket.AddProducts(new BasketItem(1, butter), new BasketItem(1, milk), new BasketItem(1, bread));
            
            Console.WriteLine("Total for case 1: ");
            Console.WriteLine(basket.CalculateSum());
            
            basket.Clear();
            basket.AddProducts(new BasketItem(2, butter), new BasketItem(2, bread));
            
            Console.WriteLine("Total for case 2: ");
            Console.WriteLine(basket.CalculateSum());
            
            basket.Clear();
            basket.AddProducts(new BasketItem(4, milk));
            
            Console.WriteLine("Total for case 3: ");
            Console.WriteLine(basket.CalculateSum());
            
            basket.Clear();
            basket.AddProducts(new BasketItem(2, butter), new BasketItem(1, bread), new BasketItem(8, milk));
            
            Console.WriteLine("Total for case 4:");
            Console.WriteLine(basket.CalculateSum());
        }
    }
}