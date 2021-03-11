using ShoppingBasket.Compiler;

namespace ShoppingBasket
{
    public interface ILogger<T>
    {
        public void Log(T details);
    }
}