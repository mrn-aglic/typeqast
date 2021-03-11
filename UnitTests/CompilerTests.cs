using NUnit.Framework;
using ShoppingBasket;
using ShoppingBasket.Compiler;
using ShoppingBasket.Model;

namespace UnitTests
{
    public class CompilerTests
    {
        private DiscountCompiler _compiler;

        [SetUp]
        public void SetUp()
        {
            _compiler = new DiscountCompiler();
        }

        [Test, TestCaseSource(typeof(CompilerData))]
        public void TestDiscountCompilation(Discount discount, CompilerResult compilerResult)
        {
            var basketItem1 = new BasketItem(2, null);
            var basketItem2 = new BasketItem(4, null);

            Assert.AreEqual(compilerResult.CompiledRule(basketItem1),
                _compiler.Compile(discount).CompiledRule(basketItem1));
            Assert.AreEqual(compilerResult.CompiledRule(basketItem2),
                _compiler.Compile(discount).CompiledRule(basketItem2));

            var actual = _compiler.Compile(discount);
            Assert.AreEqual(compilerResult.CompiledDiscount(compilerResult.TargetProduct),
                actual.CompiledDiscount(actual.TargetProduct));

            Assert.AreSame(compilerResult.SourceProduct, actual.SourceProduct);
            Assert.AreSame(compilerResult.TargetProduct, actual.TargetProduct);
            Assert.AreEqual(compilerResult.RequiredAmount, actual.RequiredAmount);
        }
    }
}