using System;
using System.Linq.Expressions;

namespace ShoppingBasket.RuleEngine
{
    public interface IRuleEngine
    {
        protected static Expression BuildExpr<T>(Rule r, ParameterExpression parameterExpression)
        {
            var left = Expression.Property(parameterExpression, r.MemberName);
            var tProp = typeof(T).GetProperty(r.MemberName)?.PropertyType;
            
            Console.WriteLine(left.ToString());
            
            ExpressionType expressionType;

            if (ExpressionType.TryParse(r.Method, out expressionType))
            {
                var right = Expression.Constant(Convert.ChangeType(r.TargetValue, tProp));
                return BinaryExpression.MakeBinary(expressionType, left, right);
            }
            else
            {
                var method = tProp.GetMethod(r.Method);
                var paramType = method.GetParameters()[0].ParameterType;
                var right = Expression.Constant(Convert.ChangeType(r.TargetValue, paramType));
                return Expression.Call(left, method, right);
            }
        }
        public Func<T, U> Compile<T, U>(Rule r);
    }
}