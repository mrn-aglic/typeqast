using System;
using System.Linq;
using ShoppingBasket;
using ShoppingBasket.Compiler;
using ShoppingBasket.Repositories;

namespace TypequastAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var ruleRepository = new RuleRepository(productRepository);
            var discountRepository = new DiscountRepository(ruleRepository, productRepository);

            var compiler = new DiscountCompiler();
            var compiledDiscounts = compiler.Compile(discountRepository.GetFromSource());

            var discountManager = new DiscountManager(compiledDiscounts);

            var basket = new Basket(discountManager);

            var products = productRepository.GetFromSource().ToArray();
            var butter = products[0];
            var milk = products[1];
            var bread = products[2];

            basket.AddProducts(new BasketItem(1, butter), new BasketItem(1, milk), new BasketItem(1, bread));

            var logger = new FileLogger();

            Console.WriteLine("Case 1: ");
            var summary1 = basket.CalculateSum();
            Console.WriteLine(summary1);
            logger.Log(summary1);

            basket.Clear();
            basket.AddProducts(new BasketItem(2, butter), new BasketItem(2, bread));

            Console.WriteLine("Case 2: ");
            var summary2 = basket.CalculateSum();
            Console.WriteLine(summary2);
            logger.Log(summary2);

            basket.Clear();
            basket.AddProducts(new BasketItem(4, milk));

            Console.WriteLine("Case 3: ");
            var summary3 = basket.CalculateSum();
            Console.WriteLine(summary3);
            logger.Log(summary3);

            basket.Clear();
            basket.AddProducts(new BasketItem(2, butter), new BasketItem(1, bread), new BasketItem(8, milk));

            Console.WriteLine("Case 4:");
            var summary4 = basket.CalculateSum();
            Console.WriteLine(summary4);
            logger.Log(summary4);

            basket.Clear();
            basket.AddProducts(new BasketItem(2, butter), new BasketItem(1, bread), new BasketItem(9, milk));

            Console.WriteLine("Case 5:");
            var summary5 = basket.CalculateSum();
            Console.WriteLine(summary5);
            logger.Log(summary5);
        }
    }
}