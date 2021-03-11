using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using NUnit.Framework;
using ShoppingBasket;
using ShoppingBasket.RuleEngine;
using Rule = ShoppingBasket.Model.Rule;

namespace UnitTests
{
    public class RuleEngineTests
    {
        private RuleEngine _ruleEngine;
        private List<Rule> _rules;

        [SetUp]
        public void Setup()
        {
            _ruleEngine = new RuleEngine();

            var r1 = new Rule(0, null, "Num", "GreaterThanOrEqual", "2");
            var r2 = new Rule(0, null, "Num", "GreaterThanOrEqual", "4");

            _rules = new List<Rule> {r1, r2};
        }

        [Test]
        public void TestRuleCompilation()
        {
            var basketItem = new BasketItem(3, null);

            List<Func<BasketItem, bool>> gs = new List<Func<BasketItem, bool>>
            {
                basketItem => basketItem.Num >= 2,
                basketItem => basketItem.Num >= 4
            };
            var fs = _rules.Select(x => _ruleEngine.Compile<BasketItem, bool>(x));

            Assert.That(fs, Is.All.InstanceOf<Func<BasketItem, bool>>());
            Assert.AreEqual(gs.Select(g => g(basketItem)),
                fs.Select(f => f(basketItem)));
        }

        [Test]
        public void TestRuleCreation()
        {
            List<Expression<Func<BasketItem, bool>>> gs = new List<Expression<Func<BasketItem, bool>>>
            {
                basketItem => basketItem.Num >= 2,
                basketItem => basketItem.Num >= 4
            };
            var fs = _rules.Select(x => _ruleEngine.Create<BasketItem, bool>(x));

            Assert.IsTrue(fs.Zip(gs).Select(p => ExpressionEqualityComparer.Instance.Equals(p.First, p.Second))
                .All(x => x));
        }
    }
}