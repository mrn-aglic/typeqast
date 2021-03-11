using System.Collections.Generic;

namespace ShoppingBasket.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetFromSource();
    }
}