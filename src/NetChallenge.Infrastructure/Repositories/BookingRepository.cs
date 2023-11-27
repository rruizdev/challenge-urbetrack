using Microsoft.EntityFrameworkCore;
using NetChallenge.Core.Database;
using NetChallenge.Core.Domain;
using NetChallenge.Infrastructure.Abstractions;

namespace NetChallenge.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ChallengeContext _context;

        public BookingRepository(ChallengeContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> AsEnumerable() =>
            _context.Bookings
                .Include(bo => bo.Office)
                .AsEnumerable();

        public void Add(Booking _)
        {
            _context.Bookings.Add(_);
            _context.SaveChanges();
        }
    }
}