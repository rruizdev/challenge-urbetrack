using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Domain;

namespace NetChallenge.Infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly ICollection<Office> _offices;

        public OfficeRepository()
        {
            _offices = new List<Office>();
        }

        public IEnumerable<Office> AsEnumerable() => _offices.AsEnumerable();

        public void Add(Office item) => _offices.Add(item);

    }
}