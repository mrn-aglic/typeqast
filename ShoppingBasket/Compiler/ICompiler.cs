using System.Collections.Generic;
using ShoppingBasket.Model;

namespace ShoppingBasket.Compiler
{
    public interface ICompiler
    {
        public IEnumerable<CompilerResult> Compile(IEnumerable<Discount> discounts);
    }
}