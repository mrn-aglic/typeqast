using System;

namespace ShoppingBasket
{
    public class MissingPropertyException : Exception
    {
        public MissingPropertyException(string message) : base(message)
        {
        }

        public MissingPropertyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}