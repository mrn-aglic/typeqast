namespace ShoppingBasket
{
    public interface ILogger
    {
        public void Log<T>(T details);
    }
}