using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Dto.Input;
using NetChallenge.Application.Exceptions;
using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Domain;

namespace NetChallenge.Application.Validations
{
    public class BookingValidations : IBookingValidations
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly ILocationRepository _locationRepository;

        public BookingValidations(IBookingRepository bookingRepository, IOfficeRepository officeRepository, 
            ILocationRepository locationRepository)
        {
            _bookingRepository = bookingRepository;
            _officeRepository = officeRepository;
            _locationRepository = locationRepository;
        }

        public void Validate(BookOfficeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.OfficeName) || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.LocationName))
                throw new NullFieldException();

            if (!_officeRepository.AsEnumerable().Any(office => office.Name == request.OfficeName))
                throw new InvalidFieldException();

            if (!_locationRepository.AsEnumerable().Any(location => location.Name == request.LocationName))
                throw new InvalidFieldException();

            if (request.Duration <= TimeSpan.Zero)
                throw new ZeroFieldException();

            if (_bookingRepository.AsEnumerable().Any(booking => DetectOverlapping(booking, request)))
                throw new RepeatedRegistryException();
        }

        private static bool DetectOverlapping(Booking booking, BookOfficeRequest request)
        {
            var requestStartTime = request.DateTime;
            var requestEndTime = request.DateTime + request.Duration;
            var bookingStartTime = booking.DateTime;
            var bookingEndTime = booking.DateTime + booking.Duration;

            return booking.OfficeName == request.OfficeName && booking.LocationName == request.LocationName &&
                !(DateTime.Compare(bookingStartTime, requestEndTime) >= 0 ||
                DateTime.Compare(requestStartTime, bookingEndTime) >= 0);
        }
    }
}
