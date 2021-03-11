using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Compiler;
using ShoppingBasket.Model;

namespace UnitTests
{
    public class CompilerData : IEnumerable
    {
        public (Discount First, CompilerResult Second)[] Pairs { get; }

        public CompilerData()
        {
            var butter = new Product(0, "butter", 0.8);
            var milk = new Product(1, "milk", 1.15);
            var bread = new Product(2, "bread", 1.00);

            var compilerResult1 = new CompilerResult(
                butter,
                bread,
                2,
                bi => bi.Num >= 2,
                p => p.Price * 0.5
            );
            var compilerResult2 = new CompilerResult(
                milk,
                milk,
                4,
                bi => bi.Num >= 4,
                p => p.Price * 1
            );

            var crs = new List<CompilerResult>
            {
                compilerResult1, compilerResult2
            };

            var discounts = new List<Discount>
            {
                new Discount(new Rule(0, butter, "Num", "GreaterThanOrEqual", "2"),
                    bread, "Price", "Multiply", "0.5"),
                new Discount(new Rule(1, milk, "Num", "GreaterThanOrEqual", "4"),
                    milk, "Price", "Multiply", "1")
            };

            Pairs = discounts.Zip(crs).ToArray();
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var pair in Pairs)
            {
                Console.WriteLine(pair.First);
                Console.WriteLine(pair.Second);
                yield return new object[] {pair.First, pair.Second};
            }
        }
    }
}