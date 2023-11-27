using NetChallenge.Core.Database;
using NetChallenge.Core.Domain;
using NetChallenge.Infrastructure.Abstractions;

namespace NetChallenge.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ChallengeContext _context;

        public LocationRepository(ChallengeContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> AsEnumerable() =>
            _context.Locations;

        public void Add(Location _)
        {
            _context.Locations.Add(_);
            _context.SaveChanges();
        }
    }
}