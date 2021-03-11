using System;
using System.Linq.Expressions;

namespace ShoppingBasket.RuleEngine
{
    public class RuleEngine : IRuleEngine
    {
        public Expression<Func<T, U>> Create<T, U>(Rule r)
        {
            var param = Expression.Parameter(typeof(T));
            Expression expr = IRuleEngine.BuildExpr<T>(r, param);
            return Expression.Lambda<Func<T, U>>(expr, param);
        }

        public Func<T, U> Compile<T, U>(Rule r)
        {
            return Create<T, U>(r).Compile();
        }
    }
}