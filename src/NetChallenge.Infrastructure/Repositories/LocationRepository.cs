using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Domain;

namespace NetChallenge.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ICollection<Location> _locations;

        public LocationRepository()
        {
            _locations = new List<Location>();
        }

        public IEnumerable<Location> AsEnumerable() => _locations.AsEnumerable();

        public void Add(Location item) => _locations.Add(item);
    }
}