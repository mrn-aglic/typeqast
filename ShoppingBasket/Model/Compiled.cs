using System;

namespace ShoppingBasket.Model
{
    public class Compiled<T, U>
    {
        public Func<T, U> Method { get; }

        public Compiled(Func<T, U> method)
        {
            Method = method;
        }
    }
}