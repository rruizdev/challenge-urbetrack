using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Domain;

namespace NetChallenge.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ICollection<Booking> _bookings;

        public BookingRepository()
        {
            _bookings = new List<Booking>();
        }

        public IEnumerable<Booking> AsEnumerable() => _bookings.AsEnumerable();

        public void Add(Booking item) => _bookings.Add(item);
    }
}