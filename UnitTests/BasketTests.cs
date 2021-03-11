using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShoppingBasket;
using Moq;
using ShoppingBasket.Compiler;
using ShoppingBasket.Model;
using ShoppingBasket.Repositories;

namespace UnitTests
{
    public class BasketTests
    {
        private Basket _shoppingBasket;
        private Mock<ICompiler> _compilerMock;
        private DiscountManager _discountManager;

        [SetUp]
        public void SetUp()
        {
            var compilerDataExpected = new CompilerData().Pairs.Select(x => x.Second);
            _compilerMock = new Mock<ICompiler>();
            _compilerMock.Setup(c => c.Compile(It.IsAny<IEnumerable<Discount>>()))
                .Returns(compilerDataExpected);

            _discountManager =
                new DiscountManager(_compilerMock.Object, new Mock<IRepository<Discount>>().Object);
            _shoppingBasket = new Basket(_discountManager);
        }

        [Test]
        public void TestAddItems()
        {
            var butter = new Product(0, "Butter", 0.8);
            var milk = new Product(1, "Milk", 1.15);
            var bread = new Product(2, "Bread", 1.00);

            var expecteds = new List<BasketItem>
            {
                new BasketItem(2, butter),
                new BasketItem(2, milk),
                new BasketItem(3, bread)
            };

            _shoppingBasket.Add(expecteds[0]);

            Assert.AreEqual(1, _shoppingBasket.GetCollectionCopy().Count);

            _shoppingBasket.AddProducts(expecteds[1], expecteds[2]);

            Assert.AreEqual(3, _shoppingBasket.GetCollectionCopy().Count);
            Assert.IsTrue(_shoppingBasket.GetCollectionCopy().Values.Sum(x => x.Num) ==
                          expecteds.Sum(x => x.Num));

            var expectedIds = expecteds.Select(x => x.Product.Id);
            Assert.AreEqual(expectedIds, _shoppingBasket.GetCollectionCopy().Keys);
        }

        [Test, TestCaseSource(typeof(DiscountCalculateData))]
        public void TestCalculateSum(double price, params BasketItem[] items)
        {
            _shoppingBasket.Clear();
            _shoppingBasket.AddProducts(items);

            Assert.AreEqual(Math.Round(price, 3), _shoppingBasket.CalculateSum());
        }
    }
}