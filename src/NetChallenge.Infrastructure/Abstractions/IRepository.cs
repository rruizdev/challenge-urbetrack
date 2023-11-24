namespace NetChallenge.Infrastructure.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        void Add(T item);
    }
}