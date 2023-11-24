using System.Collections.Generic;

namespace NetChallenge.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        void Add(T item);
    }
}